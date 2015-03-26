using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlparse
{
    class Word
    {
        private string value;
        private string key;
        private string pre_mark;
        private string beh_mark;
        private int pre_index;

        public int Pre_index
        {
            get { return pre_index; }
            set { pre_index = value; }
        }
        private int beh_index;

        public int Beh_index
        {
            get { return beh_index; }
            set { beh_index = value; }
        }

        public Word(string premark)
        {
            this.pre_mark = pre_mark;
            this.pre_index = 0;
            this.beh_index = 0;
        }

        public Word()
        {
            this.pre_index = 0;
            this.beh_index = 0;
        }


        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
      

        public string Key
        {
            get { return this.key; }
            set { this.key = value; }
        }
     

        public string Pre_mark
        {
            get { return this.pre_mark; }
            set { this.pre_mark = value; }
        }
      

        public string Beh_mark
        {
            get { return this.beh_mark; }
            set { this.beh_mark = value; }
        }

        public int getValueLength(){
            return this.beh_index - this.pre_index;
        }

    }
}
