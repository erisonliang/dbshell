﻿using System;

namespace RazorEngine.Templating
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// Provides a base implementation of a template.
    /// </summary>
    public abstract class TemplateBase : ITemplate
    {
        #region Constructor
        /// <summary>
        /// Initialises a new instance of <see cref="TemplateBase"/>.
        /// </summary>
        protected TemplateBase()
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the template service.
        /// </summary>
        public TemplateService Service { get; set; }

        /// <summary>
        /// Gets or sets output stream
        /// </summary>
        public TextWriter Output { get; set; }
        #endregion

        #region Methods


        public virtual void Clear()
        {
            int x = 0;
        }

        /// <summary>
        /// Executes the compiled template.
        /// </summary>
        public virtual void Execute() { }

        /// <summary>
        /// Includes the template with the specified name.
        /// </summary>
        /// <param name="name">The template name.</param>
        /// <returns>The result of the template with the specified name.</returns>
        public virtual string Include(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name of the template to include is required.");

            if (Service == null)
                throw new InvalidOperationException("No template serice has been set of this template.");

            return Service.ResolveTemplate(name);
        }

        /// <summary>
        /// Includes the template with the specified name.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="name">The template name.</param>
        /// <param name="model">The model required by the template.</param>
        /// <returns>The result of the template with the specified name.</returns>
        public virtual string Include<T>(string name, T model)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name of the template to include is required.");

            if (Service == null)
                throw new InvalidOperationException("No template serice has been set of this template.");

            return Service.ResolveTemplate(name, model);
        }

        /// <summary>
        /// Writes the specified object to the template result.
        /// </summary>
        /// <param name="object">The object to write.</param>
        public void Write(object @object)
        {
            if (@object == null)
                return;

            Output.Write(@object);
        }

        /// <summary>
        /// Writes the specified string to the template result.
        /// </summary>
        /// <param name="string">The string to write.</param>
        public void WriteLiteral(string @string)
        {
            if (@string == null)
                return;

            Output.Write(@string);
        }

        /// <summary>
        /// Writes a string literal to the specified <see cref="TextWriter"/>.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="literal">The literal to be written.</param>
        public static void WriteLiteralTo(TextWriter writer, string literal)
        {
            if (literal == null)
                return;

            writer.Write(literal);
        }

        /// <summary>
        /// Writes the specified object to the specified <see cref="TextWriter"/>.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="obj">The object to be written.</param>
        public static void WriteTo(TextWriter writer, object obj)
        {
            if (obj == null)
                return;

            writer.Write(obj);
        }
        #endregion
    }
}