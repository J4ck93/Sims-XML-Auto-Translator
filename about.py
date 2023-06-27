# Import required libraries
import tkinter as tk
from tkinter import ttk
from datetime import datetime
import os
import _constants as ct
import sys
import webbrowser

def callback(url):
    # Function to open a URL in the default web browser
    webbrowser.open_new(url)

def change_cursor(event):
    # Function to change the cursor to a hand pointer
    event.widget.config(cursor="hand2")

def reset_cursor(event):
    # Function to reset the cursor to the default
    event.widget.config(cursor="")

def show_window():
    # Function to create and display the about window

    # Create the main application window
    window = tk.Toplevel()
    window.title(f"About {ct.NAME} {ct.VERSION}")  # Set window title

    if getattr(sys, 'frozen', False):
        application_path = sys._MEIPASS
    elif __file__:
        application_path = os.path.dirname(__file__)

    iconFile = 'icon.ico'
    window.iconbitmap(default=os.path.join(application_path, iconFile))  # Set window icon

    # Set window size and position
    width = 560
    height = 145
    screenwidth = window.winfo_screenwidth()
    screenheight = window.winfo_screenheight()
    alignstr = '%dx%d+%d+%d' % (width, height, (screenwidth - width) / 2, (screenheight - height) / 2)
    window.geometry(alignstr)
    window.resizable(width=False, height=False)  # Make the window not resizable

    build_date = datetime.utcfromtimestamp(ct.BUILD_DATE)

    text = f"""{ct.NAME}
Version: {ct.VERSION}
Compiled {build_date.strftime('%b %d %Y %H:%M:%S')}
Author: {ct.AUTHOR}
"""

    text_1 = tk.Text(window, height=5)
    text_1.pack()

    text_1.insert(tk.END, text)
    text_1.insert(tk.END, "https://github.com/UmaruMG", "link")
    text_1.tag_configure("link", foreground="blue", underline=True)
    text_1.tag_bind("link", "<Button-1>", lambda e: callback("https://github.com/UmaruMG"))
    text_1.tag_bind("link", "<Enter>", change_cursor)
    text_1.tag_bind("link", "<Leave>", reset_cursor)

    text_1.config(font=("Arial", 10))

    separator = ttk.Separator(window, orient='horizontal')
    separator.pack(fill='x')

    text_2 = tk.Text(window, height=1)
    text_2.pack()

    text_2.insert(tk.END, "Sims XML Auto Translator is a simple Tool to Update Translations with DeepL Automaticly.")

    text_2.config(font=("Arial", 10))

    separator2 = ttk.Separator(window, orient='horizontal')
    separator2.pack(fill='x')

    text_3 = tk.Text(window, height=2)
    text_3.pack()

    text_3.insert(tk.END, "Mods and Modpacks translated with Sims XML Auto Translator:\n")
    text_3.insert(tk.END, "https://patreon.com/LibDoi", "link")
    text_3.tag_configure("link", foreground="blue", underline=True)
    text_3.tag_bind("link", "<Button-1>", lambda e: callback("https://patreon.com/LibDoi"))
    text_3.tag_bind("link", "<Enter>", change_cursor)
    text_3.tag_bind("link", "<Leave>", reset_cursor)

    text_3.config(font=("Arial", 10))

    # Run the application
    window.mainloop()
