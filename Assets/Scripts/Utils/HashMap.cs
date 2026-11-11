using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using static EmployeesData;
using static Utils.SearchingUtils;

public class HashMap
{
    private List<StoredEmployee>[] hashMap;

    public HashMap(StoredEmployee[] inStoredEmployees) {
        hashMap = new List<StoredEmployee>[inStoredEmployees.Length];
        foreach(StoredEmployee se in inStoredEmployees) {
            if(hashMap[Hash(se)] == null) {
                hashMap[Hash(se)] = new();
            }
            hashMap[Hash(se)].Add(se);
        }
    }

    private int Hash(StoredEmployee value) {
        if(hashMap.Length == 0) {
            return -1;
        }
        Debug.Log(value.differenceTimeSpan.Duration().TotalMinutes);
        return (int)(value.differenceTimeSpan.Duration().TotalMinutes % hashMap.Length);
        
    }

    public List<StoredEmployee>[] GetHashMap() {
        return hashMap;
    }

    public List<Employee> GetClosestValues() {
        List<Employee> result = new List<Employee>();
        for(int i = 0; i < hashMap.Length; i++) {
            if(hashMap[i].Count > 0) {
                foreach(StoredEmployee se in hashMap[i]) {
                    result.Add(se.employee);
                }
                return result;
            }
        }
        return result;
    }
}
