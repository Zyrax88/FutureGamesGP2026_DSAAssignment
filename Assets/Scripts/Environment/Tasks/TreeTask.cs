using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using static Utils.TreeUtil;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "TreeTask", menuName = "Scriptable Objects/TreeTask")]
    public class TreeTask : Task {
        [SerializeField] ReadFileTask file;

        List<DateTime> times = new();

        public override void Execute(GameObject obj = null) {
            Helpers.SortingUtils.MergeSort(file.employees, Helpers.SortingUtils.SortingCriteria.employeeLastEntrance);

            foreach(EmployeesData.Employee e in file.employees) {
                times.Add(DateTime.ParseExact(e.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
            }


            BSTTree tree = new BSTTree(times[(times.Count/2) - 1]);

            foreach(DateTime t in times) {
                tree.Insert(t);
            }

            Debug.Log("Tree searching");

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            bool founditDFS = tree.DFSSearch(DateTime.ParseExact("2234-08-05T12:32:01", "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));

            stopwatch.Stop();

            

            Debug.Log($"DFSSearching the tree took: { stopwatch.Elapsed.TotalMilliseconds * 1000000}ns and {(founditDFS ? "found it" : "didn't find it")}");

            stopwatch.Reset();

            stopwatch.Start();

            bool founditBFS = tree.BFSSearch(DateTime.ParseExact("2234-08-05T12:32:01", "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));

            stopwatch.Stop();

            Debug.Log($"BFSSearching the tree took: {stopwatch.Elapsed.TotalMilliseconds * 1000000}ns and {(founditBFS ? "found it" : "didn't find it")}");

            stopwatch.Reset();

            double[] averageTimes = new double[1000];

            bool founditDFS2;

            for(int i = 0; i < averageTimes.Length; i++) {
                stopwatch.Start();
                founditDFS2 = tree.DFSSearch(DateTime.ParseExact("2234-08-05T12:32:01", "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                averageTimes[i] = stopwatch.Elapsed.TotalMilliseconds * 1000000;
                stopwatch.Reset();
            }

            double total = 0d;

            foreach(Double t in averageTimes) {
                total += t;
            }

            Debug.Log("Average time for DFS Tree Search:" + total / averageTimes.Length + "ns");

            stopwatch.Reset();

            bool founditDFS3;

            for(int i = 0; i < averageTimes.Length; i++) {
                stopwatch.Start();
                founditDFS2 = tree.BFSSearch(DateTime.ParseExact("2234-08-05T12:32:01", "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                averageTimes[i] = stopwatch.Elapsed.TotalMilliseconds * 1000000;
                stopwatch.Reset();
            }

            double total2 = 0d;

            foreach(Double t in averageTimes) {
                total2 += t;
            }

            Debug.Log("Average time for BFS Tree Search:" + total2 / averageTimes.Length + "ns");
        }
    }
}

