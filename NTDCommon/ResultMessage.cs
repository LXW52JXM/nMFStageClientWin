using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    //    public class ResultMessage<T> 
    //    {

    //    /**
    //     * 状态
    //     * 返回的状态码
    //     * 返回的信息
    //     * 返回的数据
    //     * 分页数量
    //     * 数据总长度
    //     */
    //    private bool status;
    //    private int? code;
    //    private string message;
    //    private T data;
    //    private int? count;
    //    private int? total;
    //}

    public class ResultMessage<T>
    {
        public bool status;
        public int? code;
        public string message;
        public T data;
        public int? count;
        public int? total;

       
        /*public ResultMessage(bool status, int? code, string message)
        {
            this.status = status;
            this.code = code;
            this.message = message;
            this.data = null;
            this.count = null;
            this.total = null;
        }
        public ResultMessage(bool status, int? code, object data)
        {
            this.status = status;
            this.code = code;
            this.message = "";
            this.data = data;
            this.count = null;
            this.total = null;
        }*/
       // public ResultMessage(bool status, int code, string message, T data, int count, int total)
       // {
       //     this.status = status;
       //     this.code = code;
       //     this.message = message;
       //     this.data = data;
       //     this.count = count;
       //     this.total = total;
       // }

       // private static ResultMessage<T> create(bool status, int code, string message, T data, int count, int total)
       // {
       //     return new ResultMessage<T>(status, code, message, data, count, total);
       // }

   
       ///* public static ResultMessage<object> success()
       // {
       //     return create(true, 200, "success", "", 0, 0);
       // }
       // public static  ResultMessage<T> success(string message)
       // {
       //     return create(true, 200, message, "", 0, 0);
       // }*/
       // public static  ResultMessage<T> success(T data)
       // {
       //     return create(true, 200, "success", data, 0, 0);
       // }
       // public static  ResultMessage<T> success(string message, T data)
       // {
       //     return create(true, 200, message, data, 0, 0);
       // }
       // public static  ResultMessage<T> success(string message, T data, int count, int total)
       // {
       //     return create(true, 200, message, data, count, total);
       // }

       // public static ResultMessage<T> success(T data, int count)
       // {
       //     return create(true, 200, "success", data, count, 0);
       // }

       


       // //系统异常
       // public static  ResultMessage<T> error(string message)
       // {
       //     return create(false, -1, message, data, 0, 0);
       // }

       // public static  ResultMessage<T> error(T data)
       // {
       //     return create(false, -1, "error", data, 0, 0);
       // }

       // public static  ResultMessage<T> error(int code, string message)
       // {
       //     return create(false, code, message, "", 0, 0);
       // }

       // public static  ResultMessage<T> error(int code, string message, T data)
       // {
       //     return create(false, code, message, data, 0, 0);
       // }
      
    }
}
