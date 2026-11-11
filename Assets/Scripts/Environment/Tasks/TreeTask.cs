using System.Collections.Generic;
using System;
using UnityEngine;
using static Utils.TreeUtil;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "TreeTask", menuName = "Scriptable Objects/TreeTask")]
    public class TreeTask : Task {
        [SerializeField] ReadFileTask file;

        List<DateTime> times = new();

        public override void Execute(GameObject obj = null) {
            foreach(EmployeesData.Employee e in file.employees) {
                times.Add(DateTime.ParseExact(e.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
            }

            BSTTree tree = new BSTTree(times[(times.Count/2) - 1]);

            foreach(DateTime t in times) {
                tree.Insert(t);
            }

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            tree.Search(DateTime.ParseExact("2234-08-05T12:32:01", "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));

            watch.Stop();

            Debug.Log(watch.Elapsed.TotalMilliseconds * 1000000 + "ns");
        }
    }
}

