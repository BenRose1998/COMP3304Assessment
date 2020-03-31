﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// ImageViewer - The Windows Form class responsible for rendering a Form displaying Images and taking inputs (next image, previous image, upload image)
    /// </summary>
    partial class ImageViewer : Form, IEventListener
    {
        // DECLARE an IFilePathAdder interface to store a reference to the FilePathHandler instance, call it '_filePathHandler':
        private IFilePathAdder _filePathHandler;

        // DECLARE a ExecuteDelegate to store the delegate to be called to issue a command:
        private ExecuteDelegate _execute;

        // DECLARE an Action<Size> to store the action that requests the next image, call it '_nextImageAction':
        private Action<Size> _retrieveImageAction;

        // DECLARE an Action to store the action that requests the next image, call it '_nextImageAction':
        private Action _nextImageAction;

        // DECLARE an Action to store the action that requests the previous image, call it '_previousImageAction':
        private Action _previousImageAction;

        public ImageViewer(IFilePathAdder filePathHandler, ExecuteDelegate execute, Action<Size> retrieveImage, Action nextImage, Action previousImage)
        {
            // Base method call
            InitializeComponent();

            // INSTANTIATE the local '_filePathHandler', with the passed 'filePathHandler'
            _filePathHandler = filePathHandler;

            // INSTANTIATE '_execute' with the passed delegate:
            _execute = execute;

            // INSTANTIATE '_retrieveImageAction' with the passed action:
            _retrieveImageAction = retrieveImage;

            // INSTANTIATE '_nextImageAction' with the passed action:
            _nextImageAction = nextImage;

            // INSTANTIATE '_previousImageAction' with the passed action:
            _previousImageAction = previousImage;
        }

        /// <summary>
        /// Called when 'loadImageButton' button is clicked. Event used to open a File Dialog popup to select an image to load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            // Open file explorer dialog and store the result in a DialogResult, call it 'result':
            DialogResult result = openFileDialog.ShowDialog();

            // Check if the result is OK
            if(result == DialogResult.OK)
            {
                // Store the name of the file that has been selected, call it 'fileName':
                string fileName = openFileDialog.FileName;

                // Calls the add method on the 'filePathHandler', passing the 'fileName'
                _filePathHandler.Add(fileName);

                // Execute the retrieve image command
                ICommand retImage = new Command<Size>(_retrieveImageAction, imageBox.Size);
                _execute(retImage);
            }
        }

        // Event Listener
        public void OnNewInput(object source, ImageEventArgs args)
        {
            // Check for the new image data
            if (args.image != null)
            {
                // Set form's image box to that image
                imageBox.Image = args.image;
            }
        }

        /// <summary>
        /// Called when 'nextButton' button is clicked. Event used to display the next image by executing nextImage command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            // Execute the next image command
            ICommand nextImage = new Command(_nextImageAction);
            _execute(nextImage);
        }

        /// <summary>
        /// Called when 'previousButton' button is clicked. Event used to display the previous image by executing previousImage command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            // Execute the previous image command
            ICommand previousImage = new Command(_previousImageAction);
            _execute(previousImage);
        }

        /// <summary>
        /// When form is resized - retrieve the image again with new image box size to rescale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageViewer_ResizeEnd(object sender, EventArgs e)
        {
            // Execute the retrieve image command
            ICommand retImage = new Command<Size>(_retrieveImageAction, imageBox.Size);
            _execute(retImage);

            Console.WriteLine(imageBox.Image.Height);
        }
    }
}
