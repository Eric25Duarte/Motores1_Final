using System;
using System.Collections.Generic;
using UnityEngine;

// Exemplo de uso de Func<T> para lógica customizada
public class FuncExample : MonoBehaviour
{
    // Delegate que retorna um valor (Func)
    public Func<int, int, int> Calculate;

    private void Start()
    {
        // Soma como exemplo
        Calculate = (a, b) => a + b;
        Debug.Log($"Soma: {Calculate(2, 3)}");
    }
}

// Exemplo comparativo de struct e classe
public struct SimpleStruct
{
    public int Value;
    public SimpleStruct(int v) { Value = v; }
}

public class SimpleClass
{
    public int Value;
    public SimpleClass(int v) { Value = v; }
}

public class StructVsClassExample : MonoBehaviour
{
    void Start()
    {
        SimpleStruct s1 = new SimpleStruct(10);
        SimpleStruct s2 = s1;
        s2.Value = 20;
        Debug.Log($"Struct: s1={s1.Value}, s2={s2.Value}"); // s1=10, s2=20

        SimpleClass c1 = new SimpleClass(10);
        SimpleClass c2 = c1;
        c2.Value = 20;
        Debug.Log($"Class: c1={c1.Value}, c2={c2.Value}"); // c1=20, c2=20
    }
}

// Exemplo de componente para composição (pode ser adicionado a qualquer GameObject)
public class DamageComponent : MonoBehaviour
{
    public float Damage = 10f;
    public event Action<float> OnDamageDealt;

    public void DealDamage(IHealth target)
    {
        target.TakeDamage(Damage);
        OnDamageDealt?.Invoke(Damage);
    }
}

// Exemplo de evento customizado em Trap
public abstract class Trap : MonoBehaviour
{
    public abstract void TriggerEffect(Collider2D collider);
    public event Action<Trap, Collider2D> OnTrapTriggered;

    protected void NotifyTriggered(Collider2D collider)
    {
        OnTrapTriggered?.Invoke(this, collider);
    }
}

// Exemplo de método utilitário genérico
public static class Utils
{
    // Método genérico para filtrar uma lista
    public static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
    {
        List<T> result = new List<T>();
        foreach (var item in list)
        {
            if (predicate(item))
                result.Add(item);
        }
        return result;
    }
}
