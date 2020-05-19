using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole.工具类使用
{
    internal class NPOIHelper
    {
        public void Read()
        {
            //读取文件
            //using (FileStream fs = File.OpenRead("list.xls"))
            //{
            //    //把read excel中的内容读取到wk对象中
            //    IWorkbook wb = new HSSFWorkbook(fs);
            //    //遍历wk中每个sheet
            //    for (int i = 0; i < wb.NumberOfSheets; i++)
            //    {
            //        ISheet sheet = wb.GetSheetAt(i);
            //        Console.WriteLine("=============={0}=================", i);

            //        for (int j = 0; j < sheet.LastRowNum; j++)
            //        {
            //            //获取每一行
            //            IRow row = sheet.GetRow(j);
            //            //遍历每一个单元格
            //            for (int k = 0; k < row.LastCellNum; k++)
            //            {
            //                ICell cell = row.GetCell(k);
            //                string value = cell.ToString();
            //                Console.Write("{0}   |", value);
            //            }
            //            Console.WriteLine();
            //        }
            //    }
            //}
        }

        public void Write()
        {
            ////导出excel首先创建工作薄对象
            //IWorkbook wbook = new HSSFWorkbook();
            ////创建工作表对象
            //ISheet sheet = wbook.CreateSheet("List for person");
            ////插入行列
            //for (int i = 0; i < list.Count; i++)
            //{
            //    //在sheet中创建一行
            //    IRow row = sheet.CreateRow(i);
            //    //在该行中创建单元格
            //    row.CreateCell(0).SetCellValue(list[i].Name);
            //    row.CreateCell(1).SetCellValue(list[i].Age);
            //    row.CreateCell(2).SetCellValue(list[i].Tel);
            //}
            ////写入到文件中
            //using (FileStream fs = File.OpenWrite("list.xls"))
            //{
            //    wbook.Write(fs);
            //}
        }
    }
}