# import necessary modules
import requests
import re
import os
import json
import xml.etree.ElementTree as ET
import utils

API_KEY = ''

API_URL = "https://api.deepl.com/v2/"
API_URL_FREE = "https://api-free.deepl.com/v2/"

def set_config(key):
    # Function to set the API key in the config file
    utils.setValue("key", key)
    utils.saveConfig()
    global API_KEY
    API_KEY = key

def get_key():
    # Function to get the API key from the config file
    global API_KEY
    API_KEY = utils.getValue("key")

def usage():
    # get key
    get_key()

    # retrieve API Key
    auth_key = str(API_KEY)

    api_url = API_URL + "usage"
    if ":fx" in auth_key:
        api_url = API_URL_FREE + "usage"

    response = requests.get(
        api_url,
        headers={'Authorization': f'DeepL-Auth-Key {auth_key}'}  # include API Key in the headers
    )

    if response.status_code == 200:
        json = response.json()
        character_count = json['character_count']
        character_limit = json['character_limit']
        return {"type": "info", "message": f"Your current Usage:\nUsed: {character_count}\nLimit: {character_limit}", "invalid": False}
    elif response.status_code == 403:
        return {"type": "error", "message": f"Invalid API-Key, please update it in the Settings. Error: {response.status_code}", "invalid": True}
    elif response.status_code == 456:
        return {"type": "error", "message": f"Your Quota has exceeded! Please Upgrade to DeepL API Pro or use another API Key. Error: {response.status_code}", "invalid": False}
    elif response.status_code == 500:
        return {"type": "error", "message": f"There was a temporary problem with the DeepL Service. Please Try agin in a few seconds. Error: {response.status_code}", "invalid": False}
    else:
        return {"type": "error", "message": f"There was an error while using the API: {response.status_code} {response.reason}", "invalid": False}

# define function for translation
def translate(input, output, source_lang, target_lang, single):
    # get key
    get_key()

    # parse XML file
    tree = ET.parse(input)
    # get the root of the XML tree
    root = tree.getroot()

    # find all 'TextStringDefinition' elements in the tree
    text_string_definitions = root.findall('.//TextStringDefinition')

    # retrieve API Key
    auth_key = API_KEY

    api_url = API_URL + "translate"
    if ":fx" in auth_key:
        api_url = API_URL_FREE + "translate"

    if not single:
        # collect all text strings in a list with newlines
        text_strings = []
        for definition in text_string_definitions:
            hex_replacement2 = r"\x0a"
            hex_replacement3 = r"\x0d"
            text_string = definition.get('TextString')
            text_string = text_string.replace("\n", hex_replacement2)
            text_string = text_string.replace("\r", hex_replacement3)
            text_strings.append(text_string)

        # join all text strings with newlines
        combined_text = '\n'.join(text_strings)

        # find placeholders inside the combined text string
        placeholders = re.findall(r'{[^}]+}', combined_text)

        # dictionary to store temporary placeholders and their corresponding original placeholders
        temp_placeholders = {}
        # replace original placeholders with temporary placeholders in the combined text string
        for i, placeholder in enumerate(placeholders):
            temp_placeholder = f'__TEMPP_{i}__'
            combined_text = combined_text.replace(placeholder, temp_placeholder)
            temp_placeholders[temp_placeholder] = placeholder

        data = {'text': combined_text, 'source_lang': source_lang, 'target_lang': target_lang, 'split_sentences': 1, 'tag_handling': 'xml'}  # provide text string and languages in the data
        if source_lang == "AT":
            data = {'text': combined_text, 'target_lang': target_lang, 'split_sentences': 1, 'tag_handling': 'xml'}  # provide text string and languages in the data

        # send a POST request to DeepL API to translate the text string
        response = requests.post(
            api_url,
            headers={'Authorization': f'DeepL-Auth-Key {auth_key}'},  # include API Key in the headers
            data=data
        )

        # if the request was successful
        if response.status_code == 200:
            # get translated text string from the response
            translated_text = response.json()['translations'][0]['text']
            # replace temporary placeholders with original placeholders in the translated text string
            for temp_placeholder, placeholder in temp_placeholders.items():
                translated_text = translated_text.replace(temp_placeholder, placeholder)

            # split the translated text string back into individual text strings
            translated_texts = translated_text.split('\n')

            # loop through each 'TextStringDefinition' element
            for i, definition in enumerate(text_string_definitions):
                # get the translated text string
                translated_text = translated_texts[i]
                hex_replacement2 = bytes(r"\x0a", "utf-8").decode("unicode-escape")
                hex_replacement3 = bytes(r"\x0d", "utf-8").decode("unicode-escape")
                translated_text = translated_text.replace("\\x0a", hex_replacement2)
                translated_text = translated_text.replace("\\x0d", hex_replacement3)
                # update 'TextString' attribute with the translated text string
                definition.set('TextString', translated_text)
        elif response.status_code == 456:
            return {"type": "error", "message": f"Your Quota has exceeded! Please Upgrade to DeepL API Pro or use another API Key."}
        else:
            return {"type": "error", "message": f"There was an error while using the API: {response.status_code} {response.reason}"}

    else:
        # loop through each 'TextStringDefinition' element
        for definition in text_string_definitions:
            # get the 'TextString' attribute
            text_string = definition.get('TextString')

            # find placeholders inside the 'TextString' (placeholders are in the format '{...}')
            placeholders = re.findall(r'{[^}]+}', text_string)
            # store the original text string
            modified_text = text_string

            # dictionary to store temporary placeholders and their corresponding original placeholders
            temp_placeholders = {}
            # replace original placeholders with temporary placeholders in the text string
            for i, placeholder in enumerate(placeholders):
                # create a temporary placeholder
                temp_placeholder = f'__TEMPP_{i}__'
                # replace original placeholder with the temporary one in the text string
                modified_text = modified_text.replace(placeholder, temp_placeholder)
                # store temporary placeholder and its corresponding original placeholder in the dictionary
                temp_placeholders[temp_placeholder] = placeholder

            data = {'text': modified_text, 'source_lang': source_lang, 'target_lang': target_lang, 'split_sentences': 1, 'tag_handling': 'xml'}  # provide text string and languages in the data
            if source_lang == "AT":
                data = {'text': modified_text, 'target_lang': target_lang, 'split_sentences': 1, 'tag_handling': 'xml'}  # provide text string and languages in the data

            # send a POST request to DeepL API to translate the text string
            response = requests.post(
                api_url,
                headers={'Authorization': f'DeepL-Auth-Key {auth_key}'},  # include API Key in the headers
                data=data
            )

            # if the request was successful
            if response.status_code == 200:
                # get translated text string from the response
                translated_text = response.json()['translations'][0]['text']
                # replace temporary placeholders with original placeholders in the translated text string
                for temp_placeholder, placeholder in temp_placeholders.items():
                    translated_text = translated_text.replace(temp_placeholder, placeholder)
                # update 'TextString' attribute with the translated text string
                definition.set('TextString', translated_text)
            elif response.status_code == 456:
                return {"type": "error", "message": f"Your Quota has exceeded! Please Upgrade to DeepL API Pro or use another API Key."}
            else:
                return {"type": "error", "message": f"There was an error while using the API: {response.status_code} {response.reason}"}

    # write the XML tree into the output file, include XML declaration and use UTF-8 encoding
    #tree.write(output, encoding='utf-8', xml_declaration=True, method="xml", short_empty_elements=True)
    temp_file_path = "temp.xml"
    tree.write(temp_file_path, encoding='utf-8', xml_declaration=True, method="xml", short_empty_elements=True)

    with open(temp_file_path, "r", encoding="utf-8") as temp_file:
        xml_content = temp_file.read()
        xml_content = xml_content.replace("&#10;", "&#xA;")
        xml_content = xml_content.replace("&#13;", "&#xD;")

    with open(temp_file_path, "w", encoding="utf-8") as temp_file:
        temp_file.write(xml_content)

    with open(temp_file_path, "r", encoding="utf-8") as temp_file:
        with open(output, "w", encoding="utf-8") as final_output:
            final_output.write(temp_file.read())

    os.remove(temp_file_path)
    if not os.path.isfile(output):
        return {"type": "error", "message": f"The File was not Found at {output}"}
    return {"type": "info", "message": f"The File Generated successfully at {output}"}
