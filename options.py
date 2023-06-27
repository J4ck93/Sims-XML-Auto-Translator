import tkinter as tk
import utils

def show_window(callback):
    # Function to create and display the settings window

    def saveValues():
        # Function to save the selected values and close the window

        selected_source_language = option1.get()
        selected_target_language = option2.get()
        json_stuff = {
            "key": entryvar1.get(),
            "remSourceLang": boolvar1.get(),
            "remTargetLang": boolvar2.get(),
            "reqLinePerLine": boolvar3.get(),
            "sourceLang": utils.get_keys_from_value(source_languages, selected_source_language)[0],
            "targetLang": utils.get_keys_from_value(target_languages, selected_target_language)[0]
        }
        utils.saveConfig(json_stuff)
        callback(json_stuff)
        window.destroy()

    def remSource_clicked():
        # Function to handle the "Remember Source Language" checkbox

        if boolvar1.get() == True:  # Checkbox is selected (checked)
            dropdown1.config(state="normal")
        else:
            dropdown1.config(state="disabled")

    def remTarget_clicked():
        # Function to handle the "Remember Target Language" checkbox

        if boolvar2.get() == True:  # Checkbox is selected (checked)
            dropdown2.config(state="normal")
        else:
            dropdown2.config(state="disabled")

    # Build UI
    window = tk.Toplevel()

    # Set window size and position
    width = 310
    height = 150
    screenwidth = window.winfo_screenwidth()
    screenheight = window.winfo_screenheight()
    alignstr = '%dx%d+%d+%d' % (width, height, (screenwidth - width) / 2, (screenheight - height) / 2)
    window.geometry(alignstr)
    window.resizable(width=False, height=False)  # Make the window not resizable
    window.title("Settings")

    keyLabel = tk.Label(window)
    keyLabel.configure(justify="center", text='API Key:')
    keyLabel.place(anchor="nw", x=10, y=10)

    entryvar1 = tk.StringVar()
    entryvar1.set(utils.getValue("key"))
    entry1 = tk.Entry(window)
    entry1.config(textvariable=entryvar1)
    entry1.place(anchor="nw", width=235, x=60, y=13)

    boolvar1 = tk.BooleanVar()
    boolvar1.set(utils.getValue("remSourceLang"))
    checkbutton1 = tk.Checkbutton(window)
    checkbutton1.configure(text='Remember Source Language', variable=boolvar1, command=remSource_clicked)
    checkbutton1.place(anchor="nw", x=10, y=40)

    boolvar2 = tk.BooleanVar()
    boolvar2.set(utils.getValue("remTargetLang"))
    checkbutton2 = tk.Checkbutton(window)
    checkbutton2.configure(text='Remember Target Language', variable=boolvar2, command=remTarget_clicked)
    checkbutton2.place(anchor="nw", x=10, y=70)

    boolvar3 = tk.BooleanVar()
    boolvar3.set(utils.getValue("reqLinePerLine"))
    checkbutton3 = tk.Checkbutton(window)
    checkbutton3.configure(text='Request line per line', variable=boolvar3)
    checkbutton3.place(anchor="nw", x=10, y=100)

    # Define dictionaries of source and target languages
    source_languages = utils.source_languages
    target_languages = utils.target_languages

    # Create dictionary of language options for the dropdown menus
    language_options = {
        "Source Language": source_languages,
        "Target Language": target_languages
    }

    option1 = tk.StringVar()
    option1.set(source_languages[utils.getValue("sourceLang")])
    dropdown1 = tk.OptionMenu(window, option1, *language_options["Source Language"].values())
    dropdown1.place(anchor="nw", width=100, x=200, y=38)
    remSource_clicked()

    option2 = tk.StringVar()
    option2.set(target_languages[utils.getValue("targetLang")])
    dropdown2 = tk.OptionMenu(window, option2, *language_options["Target Language"].values())
    dropdown2.place(anchor="nw", width=100, x=200, y=68)
    remTarget_clicked()

    button1 = tk.Button(window)
    button1.configure(text='Cancel', command=window.destroy)
    button1.place(anchor="nw", x=210, y=110)

    button2 = tk.Button(window)
    button2.configure(text='Ok', command=saveValues)
    button2.place(anchor="nw", x=270, y=110)

    window.mainloop()
