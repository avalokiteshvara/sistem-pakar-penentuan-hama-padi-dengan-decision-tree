using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Wintellect.PowerCollections;

namespace DeteksiHama.Class.C45
{
    internal class c45
    {
        public DecisionTreeNode Root { get; private set; }
        private bool[] visable;
        private const int NOT_FOUND = -1;
        private const int DATA_START_LINE = 1;
        private object[] trainingArray;
        private string[] columnHeaderArray;
        private int nodeIndex;
        private string log;

        /// <param name="printData"> </param>
        /// <param name="node">  </param>
        public void forecast(string[] printData, DecisionTreeNode node)
        {
            int index = getColumnHeaderIndexByName(node.nodeName);
            if (index == NOT_FOUND)
            {
                Console.WriteLine(node.nodeName);
            }
            DecisionTreeNode[] childs = node.childNodesArray;
            foreach (DecisionTreeNode t in childs.Where(t => t != null).Where(t => t.parentArrtibute.Equals(printData[index])))
            {
                forecast(printData, t);
            }
        }

        /// <param name="array"> </param>
        /// <param name="index">  </param>
        public void create(object[] array, int index)
        {
            trainingArray = new object[array.Length - 1];
            //trainingArray = Arrays.copyOfRange(array, DATA_START_LINE, array.Length);
            Array.Copy(array, DATA_START_LINE, trainingArray, 0, array.Length - 1);
            init(array, index);
            createDecisionTree(trainingArray);
            printDecisionTree(Root);
        }

        private object[] getMaxGain(object[] array)
        {
            object[] result = new object[2];
            double gain = 0;
            int index = -1;

            for (int i = 0; i < visable.Length; i++)
            {
                if (visable[i]) continue;
                //TODO ID3 change to C4.5 
                var value = gainRatio(array, i, nodeIndex);
                Console.WriteLine(value);
                if (!(gain < value)) continue;
                gain = value;
                index = i;
            }
            result[0] = gain;
            result[1] = index;
            //TODO throws can't forecast this model exception 
            if (index != -1)
            {
                visable[index] = true;
            }
            return result;
        }

        private void createDecisionTree(object[] array)
        {
            var maxgain = getMaxGain(array);
            if (Root != null) return;
            Root = new DecisionTreeNode
                       {
                           parentNode = null,
                           parentArrtibute = null,
                           arrtibutesArray = getArrtibutesArray((int) ((int?) maxgain[1])),
                           nodeName = getColumnHeaderNameByIndex((int) ((int?) maxgain[1]))
                       };
            Root.childNodesArray = new DecisionTreeNode[Root.arrtibutesArray.Length];
            insertDecisionTree(array, Root);
        }

        private void insertDecisionTree(object[] array, DecisionTreeNode parentNode)
        {
            var arrtibutes = parentNode.arrtibutesArray;
            for (int i = 0; i < arrtibutes.Length; i++)
            {
                var pickArray = pickUpAndCreateSubArray(array, arrtibutes[i],
                                                             getColumnHeaderIndexByName(parentNode.nodeName));
                var info = getMaxGain(pickArray);
                double gain = (double) ((double?) info[0]);
                if (Math.Abs(gain - 0) > 0.000001)
                {
                    int index = (int) ((int?) info[1]);
                    DecisionTreeNode currentNode = new DecisionTreeNode
                                                       {
                                                           parentNode = parentNode,
                                                           parentArrtibute = arrtibutes[i],
                                                           arrtibutesArray = getArrtibutesArray(index),
                                                           nodeName = getColumnHeaderNameByIndex(index)
                                                       };
                    currentNode.childNodesArray = new DecisionTreeNode[currentNode.arrtibutesArray.Length];
                    parentNode.childNodesArray[i] = currentNode;
                    insertDecisionTree(pickArray, currentNode);
                }
                else
                {
                    DecisionTreeNode leafNode = new DecisionTreeNode
                                                    {
                                                        parentNode = parentNode,
                                                        parentArrtibute = arrtibutes[i],
                                                        arrtibutesArray = new string[0],
                                                        nodeName = getLeafNodeName(pickArray, nodeIndex),
                                                        childNodesArray = new DecisionTreeNode[0]
                                                    };
                    parentNode.childNodesArray[i] = leafNode;
                }
            }
        }

        private void printDecisionTree(DecisionTreeNode node)
        {
            //Console.WriteLine(node.nodeName);
            //string log = null;
            string parentName = node.parentNode == null ? "null" : node.parentNode.nodeName;

            log += string.Format("{0} [Parent Node:{1}] [Paren Att:{2}] [Child:{3}]\n", node.nodeName, parentName, node.parentArrtibute, node.childNodesArray.Length);
            DecisionTreeNode[] childs = node.childNodesArray;
            foreach (DecisionTreeNode t in childs.Where(t => t != null))
            {
                //Console.WriteLine("-" + t.parentArrtibute);
                log += string.Format("--{0} [Node Name:{2}][Attribute for {1}]\n", t.parentArrtibute, t.parentNode.nodeName, node.nodeName);
                printDecisionTree(t);
            }
        }

        public void WriteLog2Disk()
        {
            var filepath = string.Format("{0}\\tree_graph.txt", Path.GetDirectoryName(Application.ExecutablePath));
            if (true) File.WriteAllText(filepath, log);
        }

        private void init(IList<object> dataArray, int index)
        {
            nodeIndex = index;
            //init data 
            columnHeaderArray = (string[]) dataArray[0];
            visable = new bool[((string[]) dataArray[0]).Length];
            for (int i = 0; i < visable.Length; i++)
            {
                if (i == index)
                {
                    visable[i] = true;
                }
                else
                {
                    visable[i] = false;
                }
            }
        }

        private static object[] pickUpAndCreateSubArray(IEnumerable<object> array, string arrtibute, int index)
        {
            ArrayList list = new ArrayList();
            foreach (string[] strs in array.Cast<string[]>().Where(strs => strs[index].Equals(arrtibute)))
            {
                list.Add(strs);
            }

            object[] myArr = (object[]) list.ToArray(typeof (object));
            return myArr;
        }

        private double gain(ICollection<object> array, int index, int node_Index)
        {
            IEnumerable<int> counts = separateToSameValueArrays(array, node_Index);
            string[] arrtibutes = getArrtibutesArray(index);
            double _infoD = infoD(array, counts);
            double _infoaD = infoaD(array, index, node_Index, arrtibutes);
            return _infoD - _infoaD;
        }

        private IEnumerable<int> separateToSameValueArrays(IEnumerable<object> array, int node_Index)
        {
            string[] arrti = getArrtibutesArray(node_Index);
            int[] counts = new int[arrti.Length];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = 0;
            }
            foreach (string[] strs in array.Cast<string[]>())
            {
                for (int j = 0; j < arrti.Length; j++)
                {
                    if (strs[node_Index].Equals(arrti[j]))
                    {
                        counts[j]++;
                    }
                }
            }
            return counts;
        }


        private double gainRatio(ICollection<object> array, int index, int node_Index)
        {
            double _gain = gain(array, index, node_Index);
            IEnumerable<int> counts = separateToSameValueArrays(array, index);
            double splitInfo = splitInfoaD(array, counts);
            if (Math.Abs(splitInfo - 0) > 0.000001)
            {
                return _gain/splitInfo;
            }
            return 0;
        }


        private static double infoD(ICollection<object> array, IEnumerable<int> counts)
        {
            return counts.Sum(t => DecisionTreeUtil.info(t, array.Count));
        }

        private static double splitInfoaD(ICollection<object> array, IEnumerable<int> counts)
        {
            return infoD(array, counts);
        }


        private double infoaD(ICollection<object> array, int index, int node_Index, IEnumerable<string> arrtibutes)
        {
            return arrtibutes.Sum(t => infoDj(array, index, node_Index, t, array.Count));
        }

        private double infoDj(IEnumerable<object> array, int index, int node_Index, string arrtibute,
                                        int allTotal)
        {
            string[] arrtibutes = getArrtibutesArray(node_Index);
            int[] counts = new int[arrtibutes.Length];
            for (var i = 0; i < counts.Length; i++)
            {
                counts[i] = 0;
            }

            foreach (string[] strs in array.Cast<string[]>().Where(strs => strs[index].Equals(arrtibute)))
            {
                for (var k = 0; k < arrtibutes.Length; k++)
                {
                    if (strs[node_Index].Equals(arrtibutes[k]))
                    {
                        counts[k]++;
                    }
                }
            }

            var total = counts.Sum();
            var infoDj = counts.Sum(t => DecisionTreeUtil.info(t, total));
            return DecisionTreeUtil.getPi(total, allTotal)*infoDj;
        }

        private string[] getArrtibutesArray(int index)
        {
            //TreeSet<string> set = new TreeSet<string>(new SequenceComparator());
            OrderedSet<string> set = new OrderedSet<string>(new SequenceComparator());

            foreach (string[] strs in trainingArray.Cast<string[]>())
            {
                set.Add(strs[index]);
            }

            return set.ToArray();
        }

        private string getColumnHeaderNameByIndex(int index)
        {
            return columnHeaderArray.Where((t, i) => i == index).FirstOrDefault();
        }

        private string getLeafNodeName(IList<object> array, int node_Index)
        {
            if (array != null && array.Count > 0)
            {
                string[] strs = (string[]) array[0];
                return strs[node_Index];
            }
            return null;
        }

        private int getColumnHeaderIndexByName(string name)
        {
            for (var i = 0; i < columnHeaderArray.Length; i++)
            {
                if (name.Equals(columnHeaderArray[i]))
                {
                    return i;
                }
            }
            return NOT_FOUND;
        }
    }
}
