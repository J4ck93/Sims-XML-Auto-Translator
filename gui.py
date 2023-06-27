# Import required libraries
import tkinter as tk
from tkinter import filedialog
from tkinter import messagebox
from tkinter import simpledialog
import os
import main
import sys
import about
import utils

def show_about():
    about.show_window()

def show_options():
    import options

    def handle_option(option):
        if option is not None:
            # Handle selected options
            if option["remSourceLang"]:
                option_1.set(source_languages[option["sourceLang"]])
                dropdown_1.config(state="disabled")
            else:
                dropdown_1.config(state="normal")
            if option["remTargetLang"]:
                option_2.set(target_languages[option["targetLang"]])
                dropdown_2.config(state="disabled")
            else:
                dropdown_2.config(state="normal")

    options.show_window(handle_option)

# Function to select the input file
def select_file_1():
    file_path = filedialog.askopenfilename(filetypes=[("XML Files", "*.xml")])
    file_path_1.set(file_path)
    check_confirm_button_state()  # Check confirm button state after selecting the file

# Function to translate text based on user inputs
def translate_text():
    # Get the selected source and target languages
    selected_source_language = option_1.get()
    selected_target_language = option_2.get()

    if selected_source_language == selected_target_language:
        msgBox = messagebox.askquestion("Warning", "Do you really want to Translate into the same Language?", icon='warning')
        if msgBox == 'no':
            return

    # Get the file path of the input file and the output file
    input_file = file_path_1.get()
    select_file_2()
    if file_path_2.get():
        output_file = file_path_2.get()
        
        # Translate the text using the translate function from main.py
        translated = main.translate(input_file, output_file, utils.get_keys_from_value(source_languages, selected_source_language)[0], utils.get_keys_from_value(target_languages, selected_target_language)[0], utils.getValue("reqLinePerLine"))
        show_messagebox(translated["message"], translated["type"])

# Function to enable or disable the confirm button based on user input
def check_confirm_button_state():
    if file_path_1.get() and option_1.get() != "Source Language" and option_2.get() != "Target Language":
        button.config(state="normal")
        file_menu.entryconfig("Export XML", state="normal")
    else:
        button.config(state="disabled")
        file_menu.entryconfig("Export XML", state="disabled")

def show_messagebox(message, type):
    if type == 'error':
        messagebox.showerror("Error", message)
    if type == 'warning':
        messagebox.showwarning("Warning", message)
    if type == 'info':
        messagebox.showinfo("Info", message)
    
# Create the main application window
window = tk.Tk()
window.title("Sims XML Auto Translator")  # Set window title

menubar = tk.Menu(window)
window.config(menu=menubar)

file_menu = tk.Menu(menubar, tearoff=0)
file_menu.add_command(label="Import XML", command=select_file_1)
file_menu.add_command(label="Export XML", command=translate_text, state="disabled")
file_menu.add_command(label="Exit", command=window.destroy)

menubar.add_cascade(label="File", menu=file_menu)

options_menu = tk.Menu(menubar, tearoff=0)
options_menu.add_command(label="Settings", command=show_options)

menubar.add_cascade(label="Options", menu=options_menu)

help_menu = tk.Menu(menubar, tearoff=0)
help_menu.add_command(label="Check for Updates")
help_menu.add_command(label="Help")
help_menu.add_command(label="About", command=show_about)

menubar.add_cascade(label="Help", menu=help_menu)

# Set window icon
if getattr(sys, 'frozen', False):
    application_path = sys._MEIPASS
elif __file__:
    application_path = os.path.dirname(__file__)

iconFile = 'icon.ico'
window.iconbitmap(default=os.path.join(application_path, iconFile))

# Set window size and position
width = 280
height = 140
screenwidth = window.winfo_screenwidth()
screenheight = window.winfo_screenheight()
alignstr = '%dx%d+%d+%d' % (width, height, (screenwidth - width) / 2, (screenheight - height) / 2)
window.geometry(alignstr)
window.resizable(width=False, height=False)  # Make the window not resizable

# Check if the configuration file exists, prompt for API key if not
if not utils.check_if_config():
    key = simpledialog.askstring(title="What is the API Key?", prompt="API Key: ")
    main.set_config(key)

# Initialize variable for storing the file path of the input file
file_path_1 = tk.StringVar()

# Create button for selecting the input file
file_select_1_button = tk.Button(window, text="Import XML", command=select_file_1)
file_select_1_button.place(x=20, y=20, width=100, height=30)

# Initialize variable for storing the file path of the output file
file_path_2 = tk.StringVar()

# Function to select the output file
def select_file_2():
    # Set initial file name based on the input file name and the selected target language
    initial_file_name = os.path.splitext(os.path.basename(file_path_1.get()))[0] + "_" + option_2.get() + ".xml"
    file_path = filedialog.asksaveasfilename(defaultextension=".xml", initialfile=initial_file_name, filetypes=[("XML Files", "*.xml")])
    file_path_2.set(file_path)

# Function to update the state of the dropdown menus
def update_dropdowns(*args):
    check_confirm_button_state()

# Initialize variables for storing the selected source and target languages
option_1 = tk.StringVar()
option_2 = tk.StringVar()

# Define dictionaries of source and target languages
source_languages = utils.source_languages
target_languages = utils.target_languages

# Create dictionary of language options for the dropdown menus
language_options = {
    "Source Language": source_languages,
    "Target Language": target_languages
}

option_1.set("English")
if utils.getValue("remSourceLang"):
    option_1.set(source_languages[utils.getValue("sourceLang")])
option_1.trace("w", update_dropdowns)

option_2.set("English")
if utils.getValue("remTargetLang"):
    option_2.set(source_languages[utils.getValue("targetLang")])
option_2.trace("w", update_dropdowns)

# Create dropdown menus for selecting the source and target languages
dropdown_1 = tk.OptionMenu(window, option_1, *language_options["Source Language"].values())
dropdown_1.place(x=20, y=90, width=100, height=30)

if utils.getValue("remSourceLang"):
    dropdown_1.config(state="disabled")
else:
    dropdown_1.config(state="normal")

dropdown_2 = tk.OptionMenu(window, option_2, *language_options["Target Language"].values())
dropdown_2.place(x=160, y=90, width=100, height=30)

if utils.getValue("remTargetLang"):
    dropdown_2.config(state="disabled")
else:
    dropdown_2.config(state="normal")

# Create labels for the dropdown menus
label_1 = tk.Label(window, text="Input Language")
label_1.place(x=20, y=60, width=100, height=30)

label_2 = tk.Label(window, text="Output Language")
label_2.place(x=160, y=60, width=100, height=30)

# Create button for exporting the translated XML file
button = tk.Button(window, text="Export XML", command=translate_text, state="disabled")
button.place(x=160, y=20, width=100, height=30)

# Run the application
window.mainloop()
