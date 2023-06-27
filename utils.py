import json
import os

config_file = 'config.cfg'  # File name for the configuration file
json_data = {}  # Empty dictionary to store JSON data

def get_keys_from_value(d, val):
    # Returns a list of keys from dictionary 'd' that have the value 'val'
    return [k for k, v in d.items() if v == val]

source_languages = {
    'CS': 'Čeština',
    'DA': 'Dansk',
    'DE': 'Deutsch',
    'EN': 'English',
    'ES': 'Español',
    'FR': 'Français',
    'IT': 'Italiano',
    'NL': 'Nederlands',
    'NB': 'Norsk',
    'PL': 'Polski',
    'PT': 'Português (Brasil)',
    'FI': 'Suomi',
    'SV': 'Svenska',
    'RU': 'Русский',
    'JA': '日本語',
    'ZH': '简体中文',
    'KO': '한국어'
}

target_languages = {
    'CS': 'Čeština',
    'DA': 'Dansk',
    'DE': 'Deutsch',
    'EN-US': 'English',
    'ES': 'Español',
    'FR': 'Français',
    'IT': 'Italiano',
    'NL': 'Nederlands',
    'NB': 'Norsk',
    'PL': 'Polski',
    'PT-BR': 'Português (Brasil)',
    'FI': 'Suomi',
    'SV': 'Svenska',
    'RU': 'Русский',
    'JA': '日本語',
    'ZH': '简体中文',
    'KO': '한국어'
}

def getValue(key):
    # Retrieves the value associated with the given 'key' from the JSON data
    global json_data
    if not json_data:
        with open(config_file, 'r') as file:
            json_data = json.load(file)
    return json_data[key]

def setValue(key, value):
    # Sets the value for the given 'key' in the JSON data
    global json_data
    if not json_data:
        with open(config_file, 'r') as file:
            json_data = json.load(file)
    json_data[key] = value

def saveConfig(jsondata=None):
    # Saves the JSON data to the configuration file
    global json_data
    if json_data:
        with open(config_file, 'w') as file:
            json.dump(json_data, file)
    if jsondata:
        with open(config_file, 'w') as file:
            json.dump(jsondata, file)
        json_data = jsondata

def genConfig():
    # Generates a default configuration file with predefined settings
    json_string = {
        "key": "",
        "single": False,
        "remSourceLang": False,
        "sourceLang": "EN",
        "remTargetLang": False,
        "targetLang": "EN-US",
        "reqLinePerLine": False
    }
    with open(config_file, 'w') as file:
        json.dump(json_string, file)

def check_if_config():
    # Checks if the configuration file exists and generates one if not
    if os.path.isfile(config_file):
        return True
    else:
        genConfig()
        return False
