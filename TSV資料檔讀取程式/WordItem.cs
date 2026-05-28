using System;
using System.Linq;

namespace TSV資料檔讀取程式 // 記得把這裡換成你專案的 namespace
{
    public class WordItem
    {
        public string Word { get; set; }
        public string Phonogram { get; set; }
        public string SoundPath { get; set; }
        public string Explain { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        public WordItem(string str)
        {
            // 用Tab分隔字串
            string[] strLists = str.Split('\t');
            if (strLists.Length >= 3)
            {
                Word = strLists[0];
                Phonogram = strLists[1];
                SoundPath = strLists[2];
                // 處理換行符號
                Explain = string.Join(Environment.NewLine, strLists.Skip(3));
            }
        }

        public override string ToString()
        {
            return Word;
        }
    }
}