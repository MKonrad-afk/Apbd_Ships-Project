using System.Runtime.Serialization;

namespace Apbd_miniProject01;
public enum ContainerType
{
    [EnumMember(Value = "Refrigerated Container")]
    R,
    [EnumMember(Value = "Gas Container")]
    G,
    [EnumMember(Value = "Liquid Container")]
    L
    
    
}