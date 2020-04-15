﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// COMP3304 Assessment Final Milestone - by Ben Rose
/// </summary>
namespace ImageManipulationLibrary
{
    /// <summary>
    /// Flip Command Class - Executes an the Flip command
    /// </summary>
    public class FlipCommand : ICommand
    {
        // DECLARE an Action to be executed, call it '_action':
        private FlipImageDelegate _action;
        private Image _image;
        private Size _size;
        private Boolean _flipVertical;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        public FlipCommand(FlipImageDelegate action, Image image, Size size, Boolean flipVertical)
        {
            // INTIANIATE '_action' with action passed as parameter:
            _action = action;
            _image = image;
            _size = size;
            _flipVertical = flipVertical;
        }

        /// <summary>
        /// Execute this command's action
        /// </summary>
        public void Execute()
        {
            // Execute
            _action(_image, _size, _flipVertical);
        }
    }

}
