using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeteksiHama.Class.C45;

namespace DeteksiHama.Class
{
    static class ClassGenerateDBTree
    {
        static readonly ClassDbConnect _dbConnect = new ClassDbConnect();

        private static void DecisionTreeSave2DataBase(DecisionTreeNode node)
        {
            //Console.WriteLine(node.nodeName);
            //string log = null;
            var parentName = node.parentNode == null ? "NULL" : node.parentNode.nodeName;

            //log += string.Format("{0} [Parent Node:{1}] [Paren Att:{2}] [Child:{3}]\n", node.nodeName, parentName, node.parentArrtibute, node.childNodesArray.Length);            
            var q = string.Format("INSERT decision_tree(node,parent,parent_attribute,child) " +
                                  "VALUES('{0}','{1}','{2}',{3})",
                                  node.nodeName, parentName, node.parentArrtibute ?? "NULL", node.childNodesArray.Length);
            _dbConnect.ExecuteNonQuery(q);

            var childs = node.childNodesArray;
            foreach (var t in childs.Where(t => t != null))
            {
                //Console.WriteLine("-" + t.parentArrtibute);
                //log += string.Format("--{0} [Node Name:{2}][Attribute for {1}]\n", t.parentArrtibute, t.parentNode.nodeName, node.nodeName);
                DecisionTreeSave2DataBase(t);
            }
        }

        public static  void BuildDecisionTree()
        {
            _dbConnect.ExecuteNonQuery("TRUNCATE TABLE decision_tree");

            var dt = _dbConnect.GetRecord("SELECT arr_fakta,solusi " +
                                          "FROM rule");

            object[] array = new object[dt.Rows.Count + 1];


            var header =
                _dbConnect.strExecuteScalar(
                //"select GROUP_CONCAT(id order by CAST(RIGHT(id,LENGTH(id) - 1) as DECIMAL)) as id " +
                    "SELECT GROUP_CONCAT(id order by no_urut) as id " +
                    "from pertanyaan");
            string[] hdr = (header + ",Solusi").Split(',');
            array[0] = hdr;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var str = (dt.Rows[i][0] + "," + dt.Rows[i][1]).Split(',');
                array[i + 1] = str;
            }

            c45 tree = new c45();
            tree.create(array, hdr.Length - 1);
            DecisionTreeSave2DataBase(tree.Root);
            tree.WriteLog2Disk();
        }
    }
}
