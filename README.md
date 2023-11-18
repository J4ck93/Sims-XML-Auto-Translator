# Sims XML Auto Translator

# Description
The Sims XML Auto Translator is a tool designed to automatically translate Sims 4 mod XML files. It uses the DeepL API for translation, offering the power of DeepL's machine learning to provide high-quality translations. This tool can be a great asset for mod creators aiming to make their content more accessible to a global audience.

# Features
Automatic translation of XML files using the DeepL API.
User-friendly GUI, no command line knowledge required.
Can translate between multiple languages.
Can handle large XML files and translate each string individually or the entire file as a whole.

# Prerequisites
A DeepL API key, which can be obtained [here](https://www.deepl.com/pro-api?cta=header-pro-api/).

# Installation
Download the latest executable file from the [releases](https://github.com/UmaruMG/Sims-XML-Auto-Translator/releases) section of this repository.

Run the downloaded .exe file. A window will appear asking for your DeepL API key.

Enter your DeepL API key and click "OK".

# Usage
Open the application by double-clicking the .exe file.

Click on the "Import XML" button to import the XML file you want to translate.

Select the input and output languages from the dropdown menus.

Click on the "Export XML" button to start the translation. The translated XML file will be saved in the same location as the original file.

For a detailed tutorial on how to extract the XML from Sims 4 mods and use this tool for translations, please refer to this [guide](https://www.patreon.com/posts/tutorial-for-way-40094277).

# Build
This Programm has been tested with Python 10 to 11

Open a new Console (cmd, bash, etc.) and navigate to the Folder where the Source Code is.

Then install the requirements using:
```bash
pip install -r requirements.txt
```

To execute the Programm run:
```bash
python gui.py
```

## Compile to an .exe

To Compile the Code into a single .exe file you first have to install `pyinstaller` from pip:
```bash
pip install pyinstaller
```

After that make sure the `Scripts` Path is in your PATH Environment and maybe restart your console,

than you can execute this Command:
```bash
pyinstaller --icon=icon.ico --name="Sims XML Auto Translator" --add-data="icon.ico;." --onefile gui.py
```

The compiled .exe file will be in the newly created `dist` folder.

# Limitations
This tool relies on the DeepL API for translations. Please be aware of the limitations and costs associated with the usage of the DeepL API. Free DeepL API users may encounter restrictions on the volume of text that can be translated.

# Support
If you encounter any issues or have any questions about this tool, please open an [issue](https://github.com/UmaruMG/Sims-XML-Auto-Translator/issues) on GitHub.

## Translated Mods

Below is a list of some creators that have been translated using the Sims XML Auto Translator:

[Sims 4 Hidden Collection (Modpack)](https://www.patreon.com/derNeonLeon)

If you have used this tool to translate a mod and would like it listed here, please open a pull request with the necessary information.
