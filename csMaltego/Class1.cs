using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


namespace csMaltego
{
    public class MaltegoEntity
    {

        public List<List<string>> additionalFields = new List<List<string>>() { };
        List<List<string>> displayInformation = new List<List<string>>() { };
        public string weight = "200";
        public string iconURL = "";
        public string entityType;
        public string entityValue;


        public void addProperty(string fieldName = null, string displayName = null,
                             string matchingRule = null, string value = null)
        {

            this.additionalFields.Add(new List<string>() { fieldName, displayName, matchingRule, value });
        }


        public void setWeight(string w)
        {
            this.weight = w;
        }

        public void setLinkColor(string color)
        {

            this.addProperty("link#maltego.link.color", "LinkColor", "", color);
        }

        public void setLinkStyle(string style)
        {
            this.addProperty("link#maltego.link.style", "LinkStyle", "", style);
        }

        public void setLinkThickness(string thick)
        {

            this.addProperty("link#maltego.link.thickness", "Thickness", "", thick);
        }

        public void setLinkLabel(string label)
        {
            this.addProperty("link#maltego.link.label", "Label", "", label);
        }

        public void setBookmark(string bookmark)
        {
            this.addProperty("bookmark#", "Bookmark", "strict", bookmark);
        }

        public void setNote(string note)
        {
            this.addProperty("notes#", "Note", "", note);
        }

        public void setIconUrl(string url)
        {
            this.iconURL = url;
        }
    }

    public class MaltegoTransform { 
    
           //XML coding 

            /* 
              BOOKMARK_COLOR_NONE="-1"
              BOOKMARK_COLOR_BLUE="0"
              BOOKMARK_COLOR_GREEN="1"
              BOOKMARK_COLOR_YELLOW="2"
              BOOKMARK_COLOR_ORANGE="3"
              BOOKMARK_COLOR_RED="4"        
             
            LINK_STYLE_NORMAL="0"
            LINK_STYLE_DASHED="1"
            LINK_STYLE_DOTTED="2"
            LINK_STYLE_DASHDOT="3" 
            
            UIM_FATAL='FatalError'
            UIM_PARTIAL='PartialError'
            UIM_INFORM='Inform'
            UIM_DEBUG='Debug'
            
             */

            public List<MaltegoEntity> entites = new List<MaltegoEntity>() { };
            List<List<string>> UIMessages = new List<List<string>>();
            List<List<List<string>>> displayInformation = new List<List<List<string>>>() { };
            List<string> exceptions = new List<string>() { };
            

           public void addEntity(string Type, string Value)
            {
                
                MaltegoEntity Entity = new MaltegoEntity();
                Entity.entityType = Type;
                Entity.entityValue = Value;
                this.entites.Add(Entity);
                
            }

            public void addUIMessage(string message, string messageType = "Inform")
            {
                UIMessages.Add(new List<string>() { message, messageType });

            }

            public void addException(string exceptionString)
            {
                exceptions.Add(exceptionString);
            }
           
            public string returnOutput()
            {
                var sb = new StringBuilder();
                // Creating xml document.
                XmlWriter xmlWriter = XmlWriter.Create(sb);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("MaltegoMessage");
                xmlWriter.WriteStartElement("MaltegoTransformResponseMessage");
                xmlWriter.WriteStartElement("Entities");
              
                for (int i = 0; i < entites.Count;i++ )
                {
                    xmlWriter.WriteStartElement("Entity");
                    xmlWriter.WriteAttributeString("Type", entites[i].entityType.ToString());
                    xmlWriter.WriteElementString("Value", entites[i].entityValue.ToString());
                    xmlWriter.WriteElementString("Weight", entites[i].weight);

                    if (entites[i].additionalFields.Count > 0)
                    {
                        xmlWriter.WriteStartElement("AdditionalFields");
                        for (int z = 0; z < entites[i].additionalFields.Count;z++)
                        {
                            
                            xmlWriter.WriteStartElement("Field");
                            xmlWriter.WriteAttributeString("Name", entites[i].additionalFields[z][0].ToString());
                            xmlWriter.WriteAttributeString("DisplayName", entites[i].additionalFields[z][1].ToString());
                            xmlWriter.WriteAttributeString("MatchingRule", entites[i].additionalFields[z][2].ToString());
                            xmlWriter.WriteValue(entites[i].additionalFields[z][3].ToString());
                            xmlWriter.WriteEndElement();
                            
                        }
                        xmlWriter.WriteEndElement();

                    if (entites[i].iconURL.Length > 0)
                    {
                        xmlWriter.WriteStartElement("IconURL");
                        xmlWriter.WriteValue(entites[i].iconURL);
                        xmlWriter.WriteEndElement();
                    }
                        
                        
                    } 
                    xmlWriter.WriteEndElement();    
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
                return sb.ToString();
                }
            
        
        } 
    
    
    }

