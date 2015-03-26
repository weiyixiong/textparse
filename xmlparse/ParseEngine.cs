using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlparse
{
    class ParseEngine
    {
        private string template = "";
        private string docconfig = "";
        private string target = "";

        public ParseEngine(string template, string docconfig)
        {
            this.template = template;
            this.docconfig = docconfig;
        }

        public ParseEngine()
        {

        }

        public List<Word> getdocMarks(string start, string end, string target)
        {
            List<string> result = new List<string>();
            List<Word> Wordresult = new List<Word>();
            string behStr = "";
            for (int i = 0,j=0; i < target.Length; i++)
            {
             
                if (target[i] == start[0])
                {
                    if (behStr.Length > 0)
                    {
                        Wordresult[j-1].Beh_mark = behStr;
                        behStr = "";
                    }
                    string temp = "";
                    i++;
                    Word word = new Word();
                    word.Pre_mark = getheadString(target, i-2);
                    while (target[i] != end[0])
                    {
                        temp += target[i];
                        i++;
                    }
                    word.Key = temp;
                    result.Add(temp);
                    Wordresult.Add(word);
                    j++;
                }
                else if (Wordresult.Count > 0)
                {
                    behStr += target[i];
                }
            }
            return Wordresult;
        }
        private string getheadString(string target,int index)
        {
            string result = "";
            for (; index > 0 && target[index] != '}';index-- )
            {
                result = target[index] + result;
            }
         
            return result;
        }

        public List<string> gettempMarks(string start, string end, string target)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == start[0] && target[i+1] == start[1])
                {
                    i += 2;
                    string temp = "";
                    while (target[i] != end[0])
                    {
                        temp += target[i];
                        i++;
                    }
                    result.Add(temp);
                }
            }
            return result;
        }
        /// <summary>
        /// 第一轮扫描，首先扫描为中文的开头和结尾标记的值。并标记下标。
        /// </summary>
        private void Pre_Scantarget( List<Word> docMark)
        {
            for (int i = 0; i < docMark.Count; i++)
            {
                if (isDot(docMark[i]))
                    continue;
                if (docMark[i].Pre_mark == null || docMark[i].Pre_mark.Trim().Length == 0)
                    docMark[i] = begintoMark(docMark[i]);
                else if (docMark[i].Beh_mark == null || docMark[i].Beh_mark.Trim().Length == 0)
                    docMark[i] = MarktoLast(docMark[i]);
                else if (!docMark[i].Beh_mark.Equals("，") && !docMark[i].Beh_mark.Equals("。"))
                    docMark[i] = Endtohead(docMark[i]);
                else  if (!docMark[i].Pre_mark.Equals("，") && !docMark[i].Pre_mark.Equals("。"))
                    docMark[i] = headtoEnd(docMark[i],target);
              
             
            }
              

        }
        private Word MarktoLast(Word word)
        {

            int strlen = word.Pre_mark.Length;
            word.Beh_index = target.Length-1;
            for (int i = target.Length - strlen; i > 0; i--)
            {
                string temp = target.Substring(i, word.Pre_mark.Length);
                if (target.Substring(i, word.Pre_mark.Length).Equals(word.Pre_mark))
                {
                    word.Pre_index = i + word.Pre_mark.Length;
                    word.Value = target.Substring(word.Pre_index, word.getValueLength());
                    break;
                }
            }

            return word;
        }
        private Word begintoMark(Word word)
        {

            int strlen = word.Beh_mark.Length;
            word.Pre_index = 0;
            for (int i = 0; i + strlen < target.Length; i++)
            {
                if (target.Substring(i, word.Beh_mark.Length).Equals(word.Beh_mark))
                {
                    word.Beh_index = i;
                    word.Value = target.Substring(word.Pre_index, word.getValueLength());
                    break;
                }
            }
            return word;
        }
        private Word Endtohead(Word word)
        {
            Boolean findend = false;
            int strlen = word.Beh_mark.Length;
            for (int i = target.Length-strlen; i>0; i--)
            {
                string temp2 = target.Substring(i, word.Beh_mark.Length);
                if (!findend && target.Substring(i, word.Beh_mark.Length).Equals(word.Beh_mark))
                {
                    word.Beh_index = i;
                    findend = true;
                }
             //   string temp = target.Substring(i, word.Pre_mark.Length);
                if (findend && target.Substring(i,  word.Pre_mark.Length).Equals(word.Pre_mark))
                {
                    word.Pre_index = i + word.Pre_mark.Length;
                    word.Value = target.Substring(word.Pre_index, word.getValueLength());
                    break;
                }
            }
          
            return word;
        }
        private Word headtoEnd(Word word,string target)
        {
            Boolean findHead = false;
            int strlen = word.Pre_mark.Length;
            for (int i = 0; i + strlen <= target.Length; i++)
            {
                string temp = target.Substring(i, word.Pre_mark.Length);
                if (!findHead && target.Substring(i,  word.Pre_mark.Length).Equals(word.Pre_mark))
                {
                    i += word.Pre_mark.Length;
                    word.Pre_index = i;
                    findHead = true;
                    strlen = word.Beh_mark.Length;
                }
                string temp2 = target.Substring(i, word.Beh_mark.Length); 
                if (findHead && target.Substring(i,word.Beh_mark.Length).Equals(word.Beh_mark))
                {
                    word.Beh_index = i;
                    word.Value = target.Substring(word.Pre_index, word.getValueLength());
                    break;
                }
            }
            return word;
        }

        private void Secong_Scantarget(List<Word> words)
        {
            for (int i = 1; i < words.Count; i++)
            {
                if (words[i].Value == null || words[i].Value.Length == 0)
                {
                    words[i] = headtoEnd(words[i], this.target.Substring(words[i - 1].Beh_index, words[i + 1].Pre_index - words[i - 1].Beh_index));
                }
            }

        }

        private string getStringbyTemplate(List<Word> words)
        {

            Dictionary<string,Word> wordDIC=  ParseListtoDictionary(words);
            string result = "";
            for (int i = 0; i < template.Length; i++)
            {
              
                if (template[i] == '$')
                {
                    string key = getTempKey(i);
                    string temp = wordDIC[key].Value;
                    result += wordDIC[key].Value;
                    i += key.Length + 2;
                }
                else
                {
                    result += template[i];
                }
              
            }
            return result;

        }
        private Dictionary<string, Word> ParseListtoDictionary(List<Word> words)
        {
            Dictionary<string, Word> result=new Dictionary<string,Word>();
            for (int i = 0; i < words.Count; i++)
            {
                result.Add(words[i].Key,words[i]);
            }
            return result;

            

        }
        private string getTempKey(int index)
        {
            string result = "";
            int start = ++index;
            index++;
            while(template[index]!='}'){
                result += template[index];
                index++;
            }
            return result;

        }
        private Boolean isDot(Word word)
        {
            return (word.Pre_mark.Equals("。") || word.Pre_mark.Equals("，")) && (word.Beh_mark.Equals("。") || word.Beh_mark.Equals("，") );
        }
        public string ParseText(string target)
        {
            this.target = target;
            List<Word> docMark=getdocMarks("{", "}", docconfig);
            Pre_Scantarget(docMark);//第一次扫描。先找出带明确特征的可取值
            Secong_Scantarget(docMark);



            return getStringbyTemplate(docMark); ;


        }




    }
}
