﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageManipulationLibrary;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// Model Class - The purpose of this class is to store all Image objects in a container & call the ImageManipulator's method to
    /// modify these images.
    /// </summary>
    public class Model : IModel
    {
        // DECLARE an IDictionary interface for a Dictionary to store Image objects, call it '_images':
        private IDictionary<string, Image> _images;
        // DECLARE an IImageManipulator interface for the ImageManipulator object, call it '_manipulator':
        private IImageManipulator _manipulator;
        // DECLARE an IImageFactory interface for the ImageFactory object, call it '_imageFactory':
        private IImageFactory _imageFactory;

        public Model()
        {
            // INSTANTIATE '_images' as a new Dictionary to store a key and an Image object:
            _images = new Dictionary<string, Image>();
            // INSTANTIATE '_manipulator' as an instance of ImageManipulator:
            _manipulator = new ImageManipulator();
            // INSTANTIATE '_imageFactory' as an instance of ImageFactory:
            _imageFactory = new ImageFactory();
        }

        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">a vector of strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<String> load(IList<String> pathfilenames)
        {
            // Loop through all path file names
            foreach(string path in pathfilenames)
            {
                if (!_images.ContainsKey(path))
                {
                    // Call ImageFactory's Create method to create an image from it's path and add it to the '_images' dictionary
                    _images.Add(path, _imageFactory.Create(path));
                }
            }

            // Return all image keys
            return GetKeys();
        }

        /// <summary>
        /// Return a copy of the image specified by 'key', scaled according to the dimentsions of the visual container (ie frame) it will be viewed in.
        /// </summary>
        /// <param name="key">the unique identifier for the image to be returned</param>
        /// <param name="frameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="frameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image pointed identified by key</returns>
        public Image getImage(String key, int frameWidth, int frameHeight)
        {
            // Call ImageManipulator's Resize method, pass the requested image, width and height and return it
            return _manipulator.Flip(_manipulator.Resize(_images[key], frameWidth, frameHeight));
        }

        /// <summary>
        /// Loops through '_images' container and adds each key to a list of strings, returns this list (returned all image keys)
        /// </summary>
        /// <returns>A string list of all image keys</returns>
        private IList<string> GetKeys()
        {
            // DECLARE & INSTANTIATE an IList container call it 'keys' and make it a List of type string
            IList<string> keys = new List<string>();

            // Loop through all image's keys
            foreach (string key in _images.Keys)
            {
                // Add each key to the 'keys' container
                keys.Add(key);
            }

            // Return all image keys
            return keys;
        }
    }
}
