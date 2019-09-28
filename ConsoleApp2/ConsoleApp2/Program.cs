using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using NPOI.OpenXmlFormats;
using System.Runtime.InteropServices;
using System.Linq.Expressions;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 数据库连接

            //string conStr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            //try
            //{
            //    string search = "select * from Student";
            //    using (SqlConnection conn = new SqlConnection(conStr))
            //    {
            //        conn.Open();
            //        //SqlCommand cmd = new SqlCommand();
            //        //cmd.Connection = conn;
            //        //cmd.CommandType = CommandType.Text;
            //        //cmd.CommandText = "select Count(*) from SC";
            //        //int result = (int)cmd.ExecuteScalar();
            //        //cmd.CommandText = "select * from Student";
            //        //SqlDataReader dr = cmd.ExecuteReader();
            //        //while (dr.Read())
            //        //{
            //        //    Console.WriteLine(dr["Sname"].ToString()+"  "+dr["Sage"].ToString()+ "  " + dr["Ssex"].ToString());
            //        //}
            //        SqlDataAdapter sda = new SqlDataAdapter(search, conn);
            //        DataSet ds = new DataSet();
            //        sda.Fill(ds, "Student");
            //        DataTable dt = ds.Tables["Student"];
            //        DataRow dr = dt.NewRow();
            //        dr["Sid"] = "14";
            //        dr["Sname"] = "金八";
            //        dr["Sage"] = "2018-01-01 00:00:00.000";
            //        dr["Ssex"] = "男";
            //        dt.Rows.Add(dr);
            //        // 将DataSet的修改提交至“数据库”
            //        SqlCommandBuilder mySqlCommandBuilder = new SqlCommandBuilder(sda);
            //        foreach (DataRow myRow in dt.Rows)
            //        {
            //            foreach (DataColumn myColumn in dt.Columns)
            //            {
            //                Console.Write(myRow[myColumn] + "  "); //遍历表中的每个单元格
            //            }
            //            Console.WriteLine("\n");
            //        }
            //        Console.WriteLine(".....................");
            //        dt.Rows[12]["Sname"] = "鸡巴";
            //        foreach (DataRow myRow in dt.Rows)
            //        {
            //            foreach (DataColumn myColumn in dt.Columns)
            //            {
            //                Console.Write(myRow[myColumn] + "  "); //遍历表中的每个单元格
            //            }
            //            Console.WriteLine("\n");
            //        }
            //        Console.WriteLine(".....................");
            //        dt.Rows[12].Delete();
            //        foreach (DataRow myRow in dt.Rows)
            //        {
            //            foreach (DataColumn myColumn in dt.Columns)
            //            {
            //                Console.Write(myRow[myColumn] + "  "); //遍历表中的每个单元格
            //            }
            //            Console.WriteLine("\n");
            //        }
            //        sda.Update(ds, "Student");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally
            //{
            //    Console.ReadLine();
            //}

            #endregion 数据库连接

            #region 100位不重复数组

            //int[] num = GetRandom(100);
            //foreach (int item in num)
            //{
            //    Console.Write(num[item-1]+" ");
            //}

            #endregion 100位不重复数组

            #region 多态

            //Computer dell = new Computer();
            //MoblieStorage sickdick = new MoblieDisk();
            //MoblieStorage westdisk = new UDisk();
            //MoblieStorage itounch = new Mp3();
            //dell.Dev = sickdick;
            //dell.Pc_ReadData();
            //dell.Pc_WriteData();
            //dell.Dev = westdisk;
            //dell.Pc_ReadData();
            //dell.Pc_WriteData();
            //dell.Dev = itounch;
            //dell.Pc_ReadData();
            //dell.Pc_WriteData();

            #endregion 多态

            #region NPOI

            //List<Person> list = new List<Person>()
            //{
            //    new Person(){Name="张三",Age=12,Tel="123"},
            //    new Person(){Name="lisi",Age=13,Tel="123"},
            //    new Person(){Name="wangwu",Age=14,Tel="123"}
            //};

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

            #endregion NPOI

            #region 字符串插值

            //string str = "hello";
            //int i = 1;
            //Console.WriteLine($"{str} world{i + 1}");

            #endregion 字符串插值

            #region 异步方法

            //Start();
            //Task<int> task = StartAsync();
            //Thread.Sleep(5000);
            //End();
            //var i = 5;
            //var task1 = Task.Run(() =>
            //{
            //    Console.WriteLine($"first {i}");
            //});
            //i = 7;
            //var task2 = Task.Run(() =>
            //{
            //    Console.WriteLine($"second {i}");
            //});
            //Task.WaitAll(task1, task2);

            #endregion 异步方法

            #region linq小查询练习

            //List<report> lists = new List<report>
            //{
            //    new report
            //    {
            //        id = 1,
            //        date = new DateTime(2019,2,6)
            //    },
            //    new report
            //    {
            //        id = 2,
            //        date = new DateTime(2019,2,2)
            //    },
            //    new report
            //    {
            //        id = 3,
            //        date = new DateTime(2019,2,10)
            //    },
            //    new report
            //    {
            //        id = 1,
            //        date = new DateTime(2019,1,12)
            //    },
            //    new report
            //    {
            //        id = 2,
            //        date = new DateTime(2019,1,23)
            //    },
            //    new report
            //    {
            //        id = 3,
            //        date = new DateTime(2019,1,27)
            //    }
            //};

            //var ss = from list in lists
            //         orderby list.date descending
            //         group list by list.id into g
            //         select g.FirstOrDefault();
            //var ss1 = lists.OrderByDescending(o => o.date).GroupBy(g => g.id).Select(s => s.FirstOrDefault()).Take(4).ToList();
            //foreach (var item in ss)
            //{
            //    Console.WriteLine(item.id + "-" + item.date);
            //}
            //foreach (var item1 in ss1)
            //{
            //    Console.WriteLine($"{item1.id} + {item1.date}");
            //}

            #endregion linq小查询练习

            #region IQueryable 扩展方法

            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 30, 50, 60 };
            var query = (from n in list where n > 5 select n).AsQueryable();
            var age = 10;
            query = query.ConditionalWhere(() => age > 0, x => x % 5 == 0);
            var result = query.ToList();

            #endregion IQueryable 扩展方法

            Console.ReadKey();
        }

        private static void Waiting() => Console.WriteLine("waiting......");

        private static void End() => Console.WriteLine("end....");

        private static async Task<int> StartAsync()
        {
            Console.WriteLine("start...");
            HttpClient client = new HttpClient();
            Waiting();
            var result = client.GetStringAsync("https://cn.bing.com/");
            string str = await result;
            return str.Length;
        }

        public static int bbb(string str)
        {
            return 1;
        }

        #region 插入一个100位的数组，不能重复插入

        /// <summary>
        /// 获得无重复随机数组
        /// </summary>
        /// <param name="n">上限n</param>
        /// <returns>返回随机数组</returns>
        private static int[] GetRandom(int n)
        {
            //容器A和B
            int[] arryA = new int[n];
            int[] arryB = new int[n];
            //填充容器a
            for (int i = 0; i < arryA.Length; i++)
            {
                arryA[i] = i + 1;
            }
            //随机对象
            Random r = new Random();
            //最后一个元素的索引 如n=100，end=99
            int end = n - 1;
            for (int i = 0; i < n; i++)
            {
                //生成随机数 因为随机的是索引 所以从0到100取，end=100
                //一个大于等于 minValue 且小于 maxValue 的 32 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。
                //如果 minValue 等于 maxValue，则返回 minValue
                //
                int minValue = 0;
                int maxValue = end + 1;
                int ranIndex = r.Next(minValue, maxValue);
                arryB[i] = arryA[ranIndex];
                //用最后一个元素覆盖取出的元素
                arryA[ranIndex] = arryA[end];
                //缩减随机数生成的范围
                end--;
            }
            //返回生成的随机数组
            return arryB;
        }

        #endregion 插入一个100位的数组，不能重复插入
    }

    #region 虚方法抽象方法

    public class Computer
    {
        public MoblieStorage Dev { get; set; }

        public void Pc_WriteData()
        {
            Dev.Write();
        }

        public void Pc_ReadData()
        {
            Dev.Read();
        }
    }

    /// <summary>
    /// 可移动存储设备
    /// </summary>
    public abstract class MoblieStorage
    {
        public abstract void Read();

        public abstract void Write();
    }

    /// <summary>
    /// u盘
    /// </summary>
    public class UDisk : MoblieStorage
    {
        public override void Read()
        {
            Console.WriteLine("u盘读取数据");
        }

        public override void Write()
        {
            Console.WriteLine("u盘写入数据");
        }
    }

    /// <summary>
    /// 移动硬盘
    /// </summary>
    public class MoblieDisk : MoblieStorage
    {
        public override void Read()
        {
            Console.WriteLine("移动硬盘读取数据");
        }

        public override void Write()
        {
            Console.WriteLine("移动硬盘写入数据");
        }
    }

    /// <summary>
    /// mp3
    /// </summary>
    public class Mp3 : MoblieStorage
    {
        public override void Read()
        {
            Console.WriteLine("mp3读取数据");
        }

        public override void Write()
        {
            Console.WriteLine("mp3写入数据");
        }

        public void PlayMusic()
        {
            Console.WriteLine("mp3播放音乐");
        }
    }

    #endregion 虚方法抽象方法

    /// <summary>
    /// 动态linq
    /// </summary>
    public static class QueryableExensions
    {
        public static IQueryable<T> ConditionalWhere<T>(this IQueryable<T> source, Func<bool> condition, Expression<Func<T, bool>> predicate)
        {
            if (condition())
            {
                return source.Where(predicate);
            }
            return source;
        }
    }

    public class report
    {
        public int id { get; set; }
        public DateTime date { get; set; }
    }
}