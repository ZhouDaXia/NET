using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
namespace WCF
{
    /*请求-答复协定指定返回答复的方法。
     *必须根据此协定的条款发送答复并与请求相关联。*/
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int a, int b);
        [OperationContract]
        int Subtract(int a, int b);
        int Multiply(int a, int b);
    }
    /*创建单向协定*/
    [ServiceContract(Namespace = "http://Micorsoft.ServiceModel.Samples", SessionMode = SessionMode.Required)]
    public interface ICalcuatorSession
    {
        [OperationContract(IsOneWay = true)]
        void Clear();
        [OperationContract(IsOneWay = true)]
        void AddTo(double n);
        [OperationContract(IsOneWay = true)]
        void SubtractFrom(double n);
        [OperationContract(IsOneWay = true)]
        void MultiplyBy(double n);
        [OperationContract(IsOneWay = true)]
        void DivideBy(double n);
        [OperationContract]
        double Equals();
    }

    /*创建双工协定*/
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode = SessionMode.Required, CallbackContract = typeof(ICalculatorDuplexCallback))]
    public interface ICalculatorDuplex
    {
        [OperationContract(IsOneWay = true)]
        void Clear();
        [OperationContract(IsOneWay = true)]
        void AddTo(double n);
        [OperationContract(IsOneWay = true)]
        void SubtractFrom(double n);
        [OperationContract(IsOneWay = true)]
        void MultiplyBy(double n);
        [OperationContract(IsOneWay = true)]
        void DivideBy(double n);

    }

    public interface ICalculatorDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Equals(double result);
        [OperationContract(IsOneWay = true)]
        void Equation(string eqn);
    }

    /*创建类或结构的基本数据协定*/
    [DataContract]
    public class Person
    {
        [DataMember]
        internal string FullName;
        [DataMember]
        private int Age;

        private string MailingAddress;

        private string telephoneNumberValue;
        [DataMember]
        public string TelephoneNumber
        {
            get { return telephoneNumberValue; }
            set { telephoneNumberValue = value; }
        }
    }

    /*启用流处理*/
    [ServiceContract(Namespace ="http://Microsoft.ServiceModel.Samples")]
    public interface IStreamingSample
    {
        [OperationContract]
        Stream GetStream(string data);
        [OperationContract]
        bool UploadStream(Stream stream);
        [OperationContract]
        Stream EchoStream(Stream stream);
        [OperationContract]
        Stream GetReversedStream();

    }

}
