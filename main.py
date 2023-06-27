# import necessary modules
import requests
import re
import os
import json
import xml.etree.ElementTree as ET
import utils

API_KEY = ''
config_file = 'config.cfg'

API_URL = "https://api.deepl.com/v2/translate"
API_URL_FREE = "https://api-free.deepl.com/v2/translate"

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

    api_url = API_URL
    if ":fx" in auth_key:
        api_url = API_URL_FREE

    if not single:
        # collect all text strings in a list with newlines
        text_strings = []
        for definition in text_string_definitions:
            text_string = definition.get('TextString')
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

        # send a POST request to DeepL API to translate the text string
        response = requests.post(
            api_url,
            headers={'Authorization': f'DeepL-Auth-Key {auth_key}'},  # include API Key in the headers
            data={'text': combined_text, 'source_lang': source_lang, 'target_lang': target_lang, 'split_sentences': 1, 'tag_handling': 'xml'}  # provide text string and languages in the data
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

            # send a POST request to DeepL API to translate the text string
            response = requests.post(
                api_url,
                headers={'Authorization': f'DeepL-Auth-Key {auth_key}'},  # include API Key in the headers
                data={'text': modified_text, 'source_lang': source_lang, 'target_lang': target_lang, 'split_sentences': 1, 'tag_handling': 'xml'}  # provide text string and languages in the data
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
    tree.write(output, encoding='utf-8', xml_declaration=True)
    if not os.path.isfile(output):
        return {"type": "error", "message": f"The File was not Found at {output}"}
    return {"type": "info", "message": f"The File Generated successfully at {output}"}
