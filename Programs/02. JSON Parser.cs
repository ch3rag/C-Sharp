using System;
using System.Collections.Generic;
using System.Collections;

namespace JSONParser {
    public class Parser {
        private Dictionary<string, object> parsedJSON;
        private string json;
        private int index;
        private object temp;

        public void Parse(string json) {
            parsedJSON = new Dictionary<string, object>();
            this.json = json;
            this.index = -1;
            doParse(parsedJSON);
            temp = parsedJSON;
        }

        public void Traverse() {
            doTraverseDict(parsedJSON, 0);
        }

        private void doTraverseDict(Dictionary<string, object> json, int tabs) {
            foreach (KeyValuePair<string, object> pair in json) {
                string key = (pair.Key == "") ? "NULL" : pair.Key;
                if (pair.Value is string) {
                    Console.WriteLine(new String(' ', tabs) + "{0}: {1}", key, pair.Value);
                } else if (pair.Value is Dictionary<string, object>) {
                    Console.WriteLine(new String(' ', tabs) + "{0} {{ \t", key);
                    doTraverseDict((Dictionary<string, object>)pair.Value, tabs + 1);
                    Console.WriteLine(new String(' ', tabs) + "}");
                } else {
                    Console.WriteLine(new String(' ', tabs) + "{0} [ ", key);
                    doTraverseArr((ArrayList)pair.Value, tabs + 1);
                    Console.WriteLine(new String(' ', tabs) + "] ", key);
                }
            }
        }

        private void doTraverseArr(ArrayList json, int tabs) {
            foreach (object value in json) {
                if (value is string) {
                    Console.WriteLine(new String(' ', tabs) + "{0}", value);
                } else if (value is Dictionary<string, object>) {
                    Console.WriteLine(new String(' ', tabs) + "NULL {");
                    doTraverseDict((Dictionary<string, object>)value, tabs + 1);
                    Console.WriteLine(new String(' ', tabs) + "}");
                } else {
                    doTraverseArr((ArrayList)value, tabs + 1);
                }
            }
        }


        // store char and increase the pointer
        private char incPointer(int inc = 1) {
            index += inc;
            return json[index];
        }
        // store char and decrease the pointer
        private char decPointer(int inc = 1) {
            index -= inc;
            return json[index];
        }

        // array processor
        private ArrayList arrayProcessor() {
            char c;
            ArrayList values = new ArrayList();
            while ((c = incPointer()) != ']') {
                if (c == '"') {
                    values.Add(valueProcessor());
                } else if (c == '[') {
                    values.Add(arrayProcessor());
                } else if (c == '{') {
                    values.Add(dictionaryProcessor());
                }
            }
            return values;
        }

        // object procesor
        private Dictionary<string, object> dictionaryProcessor() {
            char c;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            while ((c = incPointer()) != '}') {
                // get key if exsists
                string key = "";
                if (c == ',') continue;
                if (c == '"') {
                    key = valueProcessor();
                    c = incPointer(2);
                }
                if (c == '{') {
                    dict.Add(key, dictionaryProcessor());
                } else if (c == '[') {
                    dict.Add(key, arrayProcessor());
                } else {
                    dict.Add(key, valueProcessor(c));
                }
            }
            return dict;
        }


        // value processor
        private string valueProcessor(char c = '"') {
            string value = "";
            if (c != '"') value += c.ToString();
            c = incPointer();
            while (c != '"' && c != ',' && c != ']' && c != '}') {
                value += c;
                c = incPointer();
            }
            if (c == ',' || c == ']' || c == '}') decPointer();
            return value;
        }

        private void doParse(Dictionary<string, object> dict) {
            char c = incPointer();
            string key = "";

            if (c == '"') {
                key = valueProcessor();
                c = incPointer(2);
            }


            if (c == '{') {
                Dictionary<string, object> value = dictionaryProcessor();
                dict.Add(key, value);
            } else if (c == '[') {
                ArrayList value = arrayProcessor();
                dict.Add(key, value);
            } else {
                string value = valueProcessor(c);
                dict.Add(key, value);
            }

            if (index >= json.Length - 1) return;
            c = incPointer();
            if (c == ',') doParse(dict);
        }



        public Parser GetValue(string key) {
            object value = null;
            if (((Dictionary<string, object>)this.temp).TryGetValue(key, out value)) {
                this.temp = value;
            } else {
                Console.WriteLine("Error Fetching Item!");
                return null;
            }
            return this;
        }

        public Parser GetArr(int index) {
            try {
                temp = ((ArrayList)temp)[index];
            } catch {
                Console.WriteLine("Error Fetching Item!");
                return null;
            }
            return this;
        }

        public object Get() {
            object obj = temp;
            temp = null;
            return obj;
        }
    }
}
