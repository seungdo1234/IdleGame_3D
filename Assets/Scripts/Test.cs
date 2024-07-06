using System;
using UnityEngine;

public class StructArray<T> where T : struct
{
    public T[] Array { get; set; }
    public StructArray(int size)
    {
        Array = new T[size];
    }
}    
public class RefArray<T> where T : class
{
    public T[] Array { get; set; }
    public RefArray(int size)
    {
        Array = new T[size];
    }
}
public class Base { }
public class Derived:Base { }
public class Add:Base { }
public class BaseArray<U> where U : Base
{
    public U [] Array { get; set; }
    public BaseArray(int size)
    {
        Array = new U[size];
    }
    public void CopyArray<T>(T[] Source) where T : U
    {
        Source.CopyTo(Array, 0);
    }
}

public class test : MonoBehaviour
{

    private void Start()
    {
        BaseArray<Add> addArr = new BaseArray<Add>(3);
        BaseArray<Derived> DerArr = new BaseArray<Derived>(3);
        BaseArray<Base> baseArr = new BaseArray<Base>(3);

        baseArr.CopyArray<Base>(addArr.Array);
     }
}