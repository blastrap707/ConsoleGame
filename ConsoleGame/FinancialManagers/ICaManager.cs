using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    //個人流動資産のキャッシュフローを管理するクラス
    interface ICaManager
    {

        //現時点の手元の現金
        public int Cash { get; set; }

        //現時点の返済金額
        //初期値は、１０００万
        public int DebtToPay { get; set; }

        //返済した金額
        public int PayBack { get; set; }
        

        public int TotalLendings { get; set; }

        public int TotalBorrowing { get; set; }





    }
}
