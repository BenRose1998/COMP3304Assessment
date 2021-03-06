﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ModelLibrary
{
    /// <summary>
    /// DisplayImageEventArgs - Stores an Image to be displayed in DisplayView
    /// </summary>
    public class DisplayImageEventArgs : EventArgs
    {
        /// <summary>
        /// Property stores image
        /// </summary>
        public Image image { get; }

        /// <summary>
        /// Constructor - Receives an Image, stores as member variable
        /// </summary>
        /// <param name="img">Image to be displayed</param>
        public DisplayImageEventArgs(Image img)
        {
            // SET 'image' to passed 'img':
            image = img;
        }
    }
}
