using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public partial class balance_entity
    {
            public balance_entity()
            {


            }
            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:False
            /// </summary>           

            public long id { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string des { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public DateTime? create_time { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public DateTime? update_time { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string ext1 { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string ext2 { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string ext3 { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string ext4 { get; set; }

            /// <summary>
            /// Desc:
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string ext5 { get; set; }

            /// <summary>
            /// Desc:设备编号
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string code { get; set; }

            /// <summary>
            /// Desc:设备名称
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string name { get; set; }

            /// <summary>
            /// Desc:设备硬件类型(打印机，秤，仪表)
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string hardware_type { get; set; }

            /// <summary>
            /// Desc:通讯方式（内部通讯，串口，TCP/IP）
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string communication_mode { get; set; }

            /// <summary>
            /// Desc:输出类型（continue，sice）
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string output_type { get; set; }

            /// <summary>
            /// Desc:单位
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string unit { get; set; }

            /// <summary>
            /// Desc:量程
            /// Default:
            /// Nullable:True
            /// </summary>           
            public decimal? range { get; set; }

            /// <summary>
            /// Desc:分度值
            /// Default:
            /// Nullable:True
            /// </summary>           
            public decimal? divison { get; set; }

            /// <summary>
            /// Desc:最小称量值
            /// Default:
            /// Nullable:True
            /// </summary>           
            public decimal? min_weight_value { get; set; }

            /// <summary>
            /// Desc:串口
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string serial_port { get; set; }

            /// <summary>
            /// Desc:波特率
            /// Default:
            /// Nullable:True
            /// </summary>           
            public int? baud_rate { get; set; }

            /// <summary>
            /// Desc:停止位
            /// Default:
            /// Nullable:True
            /// </summary>           
            public int? stopBit { get; set; }

            /// <summary>
            /// Desc:ip地址
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string ip { get; set; }

            /// <summary>
            /// Desc:端口
            /// Default:
            /// Nullable:True
            /// </summary>           
            public int? port { get; set; }

            /// <summary>
            /// Desc:接口示例
            /// Default:
            /// Nullable:True
            /// </summary>           
            public string interface_example { get; set; }

            /// <summary>
            /// Desc:排序
            /// Default:
            /// Nullable:True
            /// </summary>           
            public int? sort { get; set; }


            /// <summary>
            /// Desc:设备号（内部秤台的地址）
            /// Default:
            /// Nullable:True
            /// </summary>           
            public int? device_number { get; set; }


        }
}
