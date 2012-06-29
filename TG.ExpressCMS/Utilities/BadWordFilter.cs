using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace TG.ExpressCMS.UI.Utilities
{
    public class BadWordFilter
    {

        /// <summary>
        /// These are the options which I use in order to determine the way I handle any bad text
        /// </summary>
        public enum CleanUpOptions
        {
            ReplaceEachWord,
            BlankBadText,
            ReplaceWholeText
        }

        /// <summary>
        /// Private constructor and instantiate the list of regex
        /// </summary>
        private BadWordFilter()
        {
            //
            // TODO: Add constructor logic here
            //
            patterns = new List<Regex>();
        }

        /// <summary>
        /// The patterns
        /// </summary>
        private List<Regex> patterns;


        public List<Regex> Patterns
        {
            get { return patterns; }
            set { patterns = value; }
        }

        private static BadWordFilter m_instance = null;

        public static BadWordFilter Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = CreateBadWordFilter(HttpContext.Current.Server.MapPath("~/Utilities/listofwords.xml"));

                return m_instance;
            }
        }

        /// <summary>
        /// Create all the patterns required and add them to the list
        /// </summary>
        /// <param name="badWordFile"></param>
        /// <returns></returns>
        protected static BadWordFilter CreateBadWordFilter(string badWordFile)
        {
            BadWordFilter filter = new BadWordFilter();
            XmlDocument badWordDoc = new XmlDocument();
            badWordDoc.Load(badWordFile);

            //Loop through the xml document for each bad word in the list
            for (int i = 0; i < badWordDoc.GetElementsByTagName("word").Count; i++)
            {
                //Split each word into a character array
                char[] characters = badWordDoc.GetElementsByTagName("word")[i].InnerText.ToCharArray();

                //We need a fast way of appending to an exisiting string
                StringBuilder patternBuilder = new StringBuilder();

                //The start of the patterm
                patternBuilder.Append("(");

                //We next go through each letter and append the part of the pattern.
                //It is this stage which generates the upper and lower case variations
                for (int j = 0; j < characters.Length; j++)
                {
                    patternBuilder.AppendFormat("[{0}|{1}][\\W]*", characters[j].ToString().ToLower(), characters[j].ToString().ToUpper());
                }

                //End the pattern
                patternBuilder.Append(")");

                //Add the new pattern to our list.
                filter.Patterns.Add(new Regex(patternBuilder.ToString()));
            }
            return filter;
        }

        /// <summary>
        /// The function which returns the manipulated string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public string GetCleanString(string input, CleanUpOptions options)
        {
            if (options == CleanUpOptions.BlankBadText)
            {
                for (int i = 0; i < patterns.Count; i++)
                {
                    //In this instance we want to return an empty string if we find any bad word
                    if (patterns[i].Match(input).Success)
                        return String.Empty;
                }
            }
            else if (options == CleanUpOptions.ReplaceWholeText)
            {
                for (int i = 0; i < patterns.Count; i++)
                {
                    //In this instance we want to return a specified statement if we find any bad word
                    if (patterns[i].Match(input).Success)
                        return Resources.ExpressCMS.TheTextContainsUnsuitableContent;
                }
            }
            else
            {
                for (int i = 0; i < patterns.Count; i++)
                {
                    //In this instance we actually replace each instance of any bad word with a specified string.
                    input = patterns[i].Replace(input, "<span style='color:red;' ><i>**" + Resources.ExpressCMS.UnsuitableWord + "**</i></span>");
                }
            }

            //return the manipulated string
            return input;
        }
    }
}
