using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using DeteksiHama.Class;
using DeteksiHama.Class.treeNodeGraph;
using NetronLight.Enums;
using NetronLight.Shapes;

namespace DeteksiHama.Form
{
    public partial class FrmTreeGraph : System.Windows.Forms.Form
    {

        static readonly ClassDbConnect _dbConnect = new ClassDbConnect();
        //private SimpleRectangle[] arrRect;
        private TreeNode<Node>[] arrNode;


        public FrmTreeGraph()
        {
            InitializeComponent();
        }


        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }


        //private void CreateNodeGraph(int nodeId,
        //    string AttrName, string NodeName,
        //    int x, int y,
        //    int childCount)
        //{
        //    arrRect[nodeId] = graphControl1.AddShape(ShapeTypes.Rectangular, new Point(x, y)) as SimpleRectangle;
        //    var rect = arrRect[nodeId];
        //    if (rect != null)
        //    {
        //        rect.Text = string.Format("Attr:{0}\nNode:{1}", AttrName, NodeName);
        //        rect.Height = 50;
        //        rect.ShapeColor = childCount == 0 ? Color.Tomato : Color.SteelBlue;
        //    }

        //}


        private void FrmTreeGraph_Load(object sender, EventArgs e)
        {
            ClassGenerateDBTree.BuildDecisionTree();


            var dt = _dbConnect.GetRecord("SELECT id,node,parent_attribute,child " +
                                           "FROM decision_tree " +
                                           "ORDER BY id");

            // The root node.
            //TreeNode<Node> root =
            //new TreeNode<Node>(new Node("Root"));

            arrNode = new TreeNode<Node>[dt.Rows.Count];
            //arrRect = new SimpleRectangle[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //create node shape
                //CreateNodeGraph(i, dt.Rows[i][2].ToString(), dt.Rows[i][1].ToString(), (Screen.PrimaryScreen.Bounds.Width - 100) / 2, 10, int.Parse(dt.Rows[i][3].ToString()));
                //if (ReferenceEquals(dt.Rows[i][2], "NULL"))
                //{

                //}
                //else
                //{
                arrNode[i] = new TreeNode<Node>(new Node(string.Format("Attr:{0}\nNode:{1}", dt.Rows[i][2].ToString(), dt.Rows[i][1].ToString())));
                //}
                //end create
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dt2 = _dbConnect.GetRecord(string.Format("SELECT id,node " +
                                                             "FROM decision_tree " +
                                                             "WHERE parent = '{0}' " +
                                                             "ORDER BY id", dt.Rows[i][1]));

                if (dt2.Rows.Count > 0)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        //var rectangle1 = arrRect[i];
                        //if (rectangle1 != null)
                        //    graphControl1.AddConnection(
                        //        rectangle1.Connectors[0],
                        //        arrRect[int.Parse(dt2.Rows[j][0].ToString()) - 1].Connectors[3]);

                        arrNode[i].AddChild(arrNode[int.Parse(dt2.Rows[j][0].ToString()) - 1]);
                    }
                }
            }
            ArrangeTree();
        }



        // Draw the tree.
        private void picTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            arrNode[0].DrawTree(e.Graphics);
        }

        // Center the tree on the form.
        private void picTree_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }

        private void ArrangeTree()
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 0, ymin = 0;
                arrNode[0].Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it horizontally.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = 10;
                arrNode[0].Arrange(gr, ref xmin, ref ymin);
            }

            this.Refresh();
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}
