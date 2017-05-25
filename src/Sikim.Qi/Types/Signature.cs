
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Sikim.Qi.Types
{
    public class Signature
    {
        private readonly string _signature;

        public static readonly string TypeNone = "_";
        public static readonly string TypeVoid = "v";
        public static readonly string TypeBool = "b";
        public static readonly string TypeInt8 = "c";
        public static readonly string TypeUInt8 = "C";
        public static readonly string TypeInt16 = "w";
        public static readonly string TypeUInt16 = "W";
        public static readonly string TypeInt32 = "i";
        public static readonly string TypeUInt32 = "I";
        public static readonly string TypeInt64 = "l";
        public static readonly string TypeUInt64 = "L";
        public static readonly string TypeFloat = "f";
        public static readonly string TypeDouble = "d";
        public static readonly string TypeString = "s";
        public static readonly string TypeListBegin = "[";
        public static readonly string TypeListEnd = "]";
        public static readonly string TypeMapBegin = "{";
        public static readonly string TypeMapEnd = "}";
        public static readonly string TypeTupleBegin = "(";
        public static readonly string TypeTupleEnd = ")";
        public static readonly string TypeDynamic = "m";
        public static readonly string TypeRaw = "r";
        public static readonly string TypePointer = "*";
        public static readonly string TypeObject = "o";
        public static readonly string TypeVarArgs = "#";
        public static readonly string TypeKwArgs = "~";
        public static readonly string TypeUnknown = "X";
        public static readonly string MethodNameSuffix = "::";

        public Signature(string signature)
        {
            this._signature = signature;
        }

        public bool IsValid
        {
            get
            {
                return this.Type != TypeNone;
            }
        }
        public bool HasChildren
        {
            get
            {
                return Children.Count() != 0;
            }
        }

        public IList<Signature> Children
        {
            get
            {
                return new List<Signature>();
            }
        }
        public string Type
        {
            get
            {
                if (_signature == string.Empty)
                    return TypeNone;
                return _signature.First().ToString();
            }
        }

        public string Annotation
        {
            get
            {
                if (_signature == string.Empty)
                {
                    return string.Empty;
                }

                if (_signature.Last() != '>')
                {
                    return string.Empty;
                }
                var regex = new Regex("<[^>]*>");
                var res = regex.Match(_signature);
                if (res.Success)
                {
                    return _signature.Substring(res.Index + 1, _signature.Length - res.Index - 2);
                }
                return string.Empty; 
            }
        }
        public override string ToString()
        {
            return _signature;
        }

        public static string MakeTupleAnnotation(string name, string[] annotations)
        {
            var res = string.Empty;

            if (name == string.Empty && annotations.Length == 0)
            {
                return res;
            }

            var format = "<{0},{1}>";
            return string.Format(format, name, String.Join(",", annotations));
        }

        public static Signature MakeSignatureFromType(Type type)
        {
            var signatureType = "";

            if(type == typeof(void))
            {
                signatureType = Signature.TypeVoid;
            }

            if (type == typeof(StringValue) || type == typeof(string))
            {
                signatureType = Signature.TypeString;
            }

            return new Signature(signatureType);
        }

        public static Signature MakeListSignature(Signature element)
        {
            return new Signature(string.Concat(TypeListBegin, element, TypeListEnd));
        }

        public static Signature MakeKwArgsSignature(Signature element)
        {
            return new Signature(string.Concat(TypeKwArgs, element));
        }

        public static Signature MakeTupleSignature(params Signature[] element)
        {
            return new Signature(string.Concat(TypeTupleBegin, string.Join(",", element as IEnumerable<Signature>), TypeTupleEnd));
        }

        public static Signature MakeMapSignature(Signature key, Signature value)
        {
            return new Signature(string.Concat(TypeMapBegin, key, value, TypeMapEnd));
        }

        public static Signature MakeMethodSignature(MethodInfo method)
        {
            var methodSignature = "";
            methodSignature += method.Name + Signature.MethodNameSuffix;
            methodSignature += Signature.MakeSignatureFromType(method.ReturnType).ToString();
            methodSignature += "(" + String.Concat(method.GetParameters().Select(p => Signature.MakeSignatureFromType(p.ParameterType).ToString())) + ")";
            return new Signature(methodSignature);
        }

        public static Signature MakePropertySignature(PropertyInfo property)
        {
            var methodSignature = "";
            //methodSignature += property.Name + Signature.MethodNameSuffix;
            methodSignature += Signature.MakeSignatureFromType(property.PropertyType).ToString();
            return new Signature(methodSignature);
        }
    }
}
