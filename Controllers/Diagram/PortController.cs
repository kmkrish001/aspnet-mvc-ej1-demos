#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.JavaScript.DataVisualization.Models.Diagram;
using Syncfusion.JavaScript.DataVisualization.Models.Collections;
using Syncfusion.JavaScript.DataVisualization.Models;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using Syncfusion.JavaScript.DataVisualization.DiagramEnums;
using MVCSampleBrowser.Models;

namespace MVCSampleBrowser.Controllers
{
    public partial class DiagramController : Controller
    {
        // GET: Port
        public ActionResult Port()
        {
            DiagramProperties model = new DiagramProperties();
            model.Height = "550px";
            model.Width = "100%";
            model.PageSettings.ScrollLimit = ScrollLimit.Diagram;
            model.SelectionChange = "selectionChange";
            model.DefaultSettings.Connector = new Connector()
            {
                Segments = new Collection() { new Segment(Segments.Orthogonal) }
            };

            FlowShape node1 = CreateNode("node1", FlowShapes.Terminator, 60, 30, 300, 85, "Start");
            node1.Ports.Add(AddPort("n1aport", 0.5f, 1, PortShapes.Square));
            FlowShape node2 = CreateNode("node2", FlowShapes.Process, 120, 60, 300, 205, "Process");
            node2.Ports.Add(AddPort("n2aport", 0, 0.5f, PortShapes.Square));
            node2.Ports.Add(AddPort("n2bport", 0.5f, 0, PortShapes.Circle));
            node2.Ports.Add(AddPort("n2cport", 1, 0.5f, PortShapes.Square));
            node2.Ports.Add(AddPort("n2dport", 0.5f, 1, PortShapes.X));
            FlowShape node3 = CreateNode("node3", FlowShapes.Decision, 120, 60, 550, 205, "Decision");
            node3.Ports.Add(AddPort("n3aport", 0, 0.5f, PortShapes.Square));
            node3.Ports.Add(AddPort("n3bport", 0.5f, 1, PortShapes.Square));
            FlowShape node4 = CreateNode("node4", FlowShapes.Process, 120, 60, 300, 380, "Process");
            node4.Ports.Add(AddPort("n4aport", 0, 0.5f, PortShapes.X));
            node4.Ports.Add(AddPort("n4bport", 0.5f, 0, PortShapes.Circle));
            node4.Ports.Add(AddPort("n4cport", 1, 0.5f, PortShapes.Path));
            node4.Ports.Add(AddPort("n4dport", 0.5f, 1, PortShapes.Square));
            FlowShape node5 = CreateNode("node5", FlowShapes.Terminator, 60, 30, 300, 500, "End");
            node5.Ports.Add(AddPort("n5aport", 0.5f, 0, PortShapes.Square));
            FlowShape node6 = CreateNode("node6", FlowShapes.Decision, 120, 60, 100, 300, "Decision");
            node6.Ports.Add(AddPort("n6aport", 0.5f, 0, PortShapes.Square));
            node6.Ports.Add(AddPort("n6bport", 0.5f, 1, PortShapes.Square));
            FlowShape node7 = CreateNode("node7", FlowShapes.Document, 120, 60, 550, 380, "Decision");
            node7.Ports.Add(AddPort("n7aport", 0.5f, 0, PortShapes.Square));
            node7.Ports.Add(AddPort("n7bport", 0, 0.5f, PortShapes.Square));

            Connector connector1 = new Connector() { SourceNode = "node1", TargetNode = "node2", SourcePort = "n1aport", TargetPort = "n2bport", Segments = new Collection() { new Segment(Segments.Straight) } };
            Connector connector2 = new Connector() { SourceNode = "node2", TargetNode = "node3", SourcePort = "n2cport", TargetPort = "n3aport" };
            Connector connector3 = new Connector() { SourceNode = "node2", TargetNode = "node6", SourcePort = "n2aport", TargetPort = "n6aport" };
            Connector connector4 = new Connector() { SourceNode = "node6", TargetNode = "node4", SourcePort = "n6bport", TargetPort = "n4aport" };
            Connector connector5 = new Connector() { SourceNode = "node2", TargetNode = "node4", SourcePort = "n2dport", TargetPort = "n4bport", Segments = new Collection() { new Segment(Segments.Straight) } };
            Connector connector6 = new Connector() { SourceNode = "node4", TargetNode = "node5", SourcePort = "n4dport", TargetPort = "n5aport" };
            Connector connector7 = new Connector() { SourceNode = "node3", TargetNode = "node7", SourcePort = "n3bport", TargetPort = "n7aport" };
            Connector connector8 = new Connector() { SourceNode = "node7", TargetNode = "node4", SourcePort = "n7bport", TargetPort = "n4cport" };

           
            model.SetTool = "SetTool";
            model.Nodes.Add(node1);
            model.Nodes.Add(node2);
            model.Nodes.Add(node3);
            model.Nodes.Add(node4);
            model.Nodes.Add(node5);
            model.Nodes.Add(node6);
            model.Nodes.Add(node7);
            model.Connectors.Add(connector1);
            model.Connectors.Add(connector2);
            model.Connectors.Add(connector3);
            model.Connectors.Add(connector4);
            model.Connectors.Add(connector5);
            model.Connectors.Add(connector6);
            model.Connectors.Add(connector7);
            model.Connectors.Add(connector8);

            ViewData["diagramModel"] = model;
            ViewData["PortDataSource"] = DropDownData.GetColors();
            ViewData["PortBorderDataSource"] = DropDownData.GetColors();
            ViewData["VisibilityData"] = DropDownData.GetVisibilityData();
            ViewData["PortShapeData"] = DropDownData.GetShapeData();
            ViewData["setTool"] = DropDownData.GetsetTool();
            return View();
        }

        public Port AddPort(string name, float offsetX, float offsetY, PortShapes shape)
        {
            Port port = new Port();
            port.Name = name;
            port.Offset = new DiagramPoint(offsetX, offsetY);
            port.Visibility = PortVisibility.Visible;
            port.Shape = shape;
            if (shape == PortShapes.Circle)
                port.BorderColor = "#E4B123";
            else if (shape == PortShapes.X)
                port.BorderColor = "#F05023";
            else if (shape == PortShapes.Path)
            {
                port.FillColor = port.BorderColor = "#3CB549";
                port.PathData = "M6.805,0L13.61,10.703L0,10.703z";
            }
            else
                port.BorderColor = "#D572AD";
            port.ConnectorPadding = 4;
            port.Constraints = PortConstraints.Connect | PortConstraints.ConnectOnDrag;
            return port;
        }

        public FlowShape CreateNode(string name, FlowShapes shapeType, double width, double height , double offsetX , double offsetY ,string text)
        {
            FlowShape node = new FlowShape();
            node.Name = name;
            node.Width = width;
            node.Height = height;
            node.OffsetX = offsetX;
            node.OffsetY = offsetY;
            node.Shape = shapeType;
            node.Labels = new Collection();
            Syncfusion.JavaScript.DataVisualization.Models.Diagram.Label label = new Label();
            label.Text = text;
            node.Labels.Add(label);
            return node;
        }
     }
}