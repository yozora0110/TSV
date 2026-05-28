using System.Collections.ObjectModel;
using TSV資料檔讀取程式;

namespace TSV資料檔讀取程式 // 記得把這裡換成你專案的 namespace
{
    public class WordCollection : Collection<WordItem>
    {
        /// <summary>
        /// 從字串陣列載入資料
        /// </summary>
        public void LoadFromStringArray(string[] lines)
        {
            this.Clear(); // 清空現有的資料
            foreach (string line in lines)
            {
                // 產生 WordItem 物件並加入
                WordItem item = new WordItem(line);
                this.Add(item);
            }
        }
    }
}