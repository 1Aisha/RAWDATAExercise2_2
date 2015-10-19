using System;
using System.Collections.Generic;

namespace Exercise_2_2_2
{
    public static class CsvParser
    {
        public static string[] ParseLine(string line)
        {
            int pos = 0;
            List<string> fields = new List<string>();
            do
            {
                Skip(line, ref pos);
                var field = "";
                // quoted string
                if (line[pos] == '"')
                {
                    pos++; // skip the starting "
                    CheckEndOfLine(line, pos);
                    do
                    {
                        // escaped quotes
                        if(pos + 1 < line.Length && line[pos] == '"' && line[pos + 1] == '"')
                        {
                            do
                            {
                                field += line[pos];
                                pos += 2;
                            } while (pos + 1 < line.Length && line[pos] == '"' && line[pos + 1] == '"');
                        }
                        else
                        {
                            field += line[pos++];
                            while (pos + 1 < line.Length && line[pos] == '"' && line[pos + 1] == '"')
                            {
                                field += line[pos];
                                pos += 2;
                            }
                        }
                        

                        
                    } while (pos < line.Length && line[pos] != '"');
                    pos++;// skip the ending "
                    fields.Add(field);
                }
                else
                {
                    do
                    {
                        field += line[pos++];
                    } while (pos < line.Length && line[pos] != ',');
                    fields.Add(field);
                }
                Skip(line, ref pos);
                if (pos < line.Length && line[pos] != ',')
                {
                    throw new ArgumentException("Missing seperator");
                }
                pos++;
            } while (pos < line.Length);
            return fields.ToArray();
        }

        private static void Skip(string line, ref int pos)
        {
            while (pos < line.Length && Char.IsWhiteSpace(line[pos]))
            {
                pos++;
            }
        }

        private static void CheckEndOfLine(string line, int pos)
        {
            if (pos >= line.Length)
            {
                throw new ArgumentException("Unexpected end of line");
            }
        }

    }
}