using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static EmployeesData;

namespace Utils {
    public class Helpers {
        public class GenericQueue<T> {

            private List<T> queue;

            public int GetCount => queue.Count;

            public GenericQueue() {
                queue = new List<T>();
            }

            public GenericQueue(List<T> list) {
                queue = list.GetRange(0, list.Count);
            }

            public T Peek() {
                return queue[0];
            }

            public void Enqueue(T item) {
                queue.Add(item);
            }

            public T Dequeue() {
                T firstOfQueue = queue[0];
                queue.RemoveAt(0);
                return firstOfQueue;
            }

        }

        public static class SortingUtils {
            public enum SortingCriteria
            {
                employeeName = 1,
                employeeID = 2,
                employeeHasAccess = 3,
                employeeLastEntrance = 4,
                employeeLastExit = 5
            }

            public static void Bubblesort(int[] arrayToSort) {
                int temp;
                int passes = arrayToSort.Length;
                int lastElementIndex = arrayToSort.Length - 1;

                for(int i = 0; i < passes; i++) {
                    for(int j = 0; j < lastElementIndex; j++) {
                        if(arrayToSort[j + 1] < arrayToSort[j]) {
                            temp = arrayToSort[j];
                            arrayToSort[j] = arrayToSort[j + 1];
                            arrayToSort[j + 1] = temp;
                        }
                    }
                    lastElementIndex--;
                }
            }


            
            /// <summary>
            ///  Summary:
            ///     Mergesorts an array of type int[]
            /// </summary>
            public static void MergeSort(int[] arrayToSort, int left = 0, int right = -1)
            {
                if(right == -1) { right = arrayToSort.Length - 1; }

                if(left < right)
                {
                    int middle = left + ((right-left) / 2);
                    MergeSort(arrayToSort, left, middle);
                    MergeSort(arrayToSort, middle+1, right);
                    Merge(arrayToSort, left, middle, right);
                }
            }

            /// <summary>
            ///  Summary:
            ///     Mergesorts an array of type DateTime[]
            /// </summary>
            public static void MergeSort(DateTime[] arrayToSort, int left = 0, int right = -1)
            {
                if(right == -1) { right = arrayToSort.Length - 1; }

                if(left < right) {
                    int middle = left + ((right - left) / 2);
                    MergeSort(arrayToSort, left, middle);
                    MergeSort(arrayToSort, middle + 1, right);
                    Merge(arrayToSort, left, middle, right);
                }
            }

            static void Merge(int[] inArray, int left, int middle, int right)
            {
                int[] tempLeft = inArray[left..(middle + 1)];
                int[] tempRight = inArray[(middle + 1)..(right + 1)];
                int i = 0, j = 0; int k = left;

                while(i < tempLeft.Length && j < tempRight.Length)
                {
                    if(tempLeft[i] <= tempRight[j])
                    {
                        inArray[k] = tempLeft[i];
                        i++;
                    }
                    else
                    {
                        inArray[k] = tempRight[j];
                        j++;
                    }
                    k++;
                }

                while(i < tempLeft.Length)
                {
                    inArray[k] = tempLeft[i];
                    i++;
                    k++;
                }

                while(j < tempRight.Length)
                {
                    inArray[k] = tempRight[j];
                    j++;
                    k++;
                }

            }

            static void Merge(DateTime[] inArray, int left, int middle, int right) {
                DateTime[] tempLeft = inArray[left..(middle+1)];
                DateTime[] tempRight = inArray[(middle+1)..(right+1)];
                int i = 0, j = 0; int k = left;

                while(i < tempLeft.Length && j < tempRight.Length) {
                    if(tempLeft[i].CompareTo(tempRight[j]) <= 0) {
                        inArray[k] = tempLeft[i];
                        i++;
                    }
                    else {
                        inArray[k] = tempRight[j];
                        j++;
                    }
                    k++;
                }

                while(i < tempLeft.Length) {
                    inArray[k] = tempLeft[i];
                    i++;
                    k++;
                }

                while(j < tempRight.Length) {
                    inArray[k] = tempRight[j];
                    j++;
                    k++;
                }

            }

            public static void MergeSort(Employee[] arrayToSort, SortingCriteria criteria, int left = 0, int right = -1, bool isDescending = false) {

                if(right == -1) { right = arrayToSort.Length - 1; }

                if(left < right)
                {
                    int middle = left + ((right - left) / 2);
                    MergeSort(arrayToSort, criteria, left, middle, isDescending);
                    MergeSort(arrayToSort, criteria, middle + 1, right, isDescending);
                    Merge(arrayToSort, criteria, left, middle, right, isDescending);
                }
            }

            static void Merge(Employee[] inArray, SortingCriteria criteria, int left, int middle, int right, bool isDescending) {
                Employee[] tempLeft = inArray[left..(middle + 1)];
                Employee[] tempRight = inArray[(middle + 1)..(right + 1)];
                int i = 0, j = 0; int k = left;

                bool comparison = false;

                while(i < tempLeft.Length && j < tempRight.Length) {

                    SwitchCheck(criteria, out comparison, inArray, i, j, tempLeft, tempRight, isDescending);
                    

                    if(comparison) {
                        inArray[k] = tempLeft[i];
                        i++;
                    }
                    else {
                        inArray[k] = tempRight[j];
                        j++;
                    }
                    k++;
                }

                while(i < tempLeft.Length) {
                    inArray[k] = tempLeft[i];
                    i++;
                    k++;
                }

                while(j < tempRight.Length) {
                    inArray[k] = tempRight[j];
                    j++;
                    k++;
                }

            }

            static void SwitchCheck(SortingCriteria criteria, out bool comparison, Employee[] inArray, int i, int j, Employee[] tempLeft, Employee[] tempRight, bool isDescending = false)
            {
                switch(criteria) {
                    case SortingCriteria.employeeID:
                        comparison = tempLeft[i].employeeId <= tempRight[j].employeeId;
                        break;

                    case SortingCriteria.employeeName:
                        comparison = string.Compare(tempLeft[i].name, tempRight[j].name) <= 0;
                        break;

                    case SortingCriteria.employeeLastEntrance:
                        comparison = DateTime.ParseExact(tempLeft[i].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
                           .CompareTo(DateTime.ParseExact(tempRight[j].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) <= 0;
                        break;

                    case SortingCriteria.employeeLastExit:
                        comparison = DateTime.ParseExact(tempLeft[i].lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
                            .CompareTo(DateTime.ParseExact(tempRight[j].lastExitFromEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) <= 0;
                        break;

                    case SortingCriteria.employeeHasAccess:
                        comparison = tempLeft[i].hasEngineRoomClearance.CompareTo(tempRight[j].hasEngineRoomClearance) <= 0;
                        break;
                    default:
                        throw new ArgumentException("Stupid");
                }

                if(isDescending) comparison = !comparison;
            }
        }
    }
}
