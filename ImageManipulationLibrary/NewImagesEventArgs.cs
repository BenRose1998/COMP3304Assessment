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
    public class NewImagesEventArgs : EventArgs
    {
        /// <summary>
        /// Property stores updated image
        /// </summary>
        public IDictionary<int, Image> images { get; }

        public NewImagesEventArgs(IDictionary<int, Image> imgs)
        {
            images = imgs;
        }
    }
}
