using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircuitSimulator.Controller;
using CircuitSimulator.Model;

namespace CircuitSimulator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests if all nodes give the expected outputs. 
        /// </summary>
        [TestMethod]
        public void TestNodes()
        {
            TestNode(typeof(AndNode), true, false, false);
            TestNode(typeof(NAndNode), false, true, true);
            TestNode(typeof(NOrNode), false, false, true);
            TestNode(typeof(OrNode), true, true, false);
            TestNode(typeof(XOrNode), false, true, false);

            TestNode(typeof(NotNode), false, true);
        }

        /// <summary>
        /// Tests if linking nodes together in a circuit gives the expected output. 
        /// </summary>
        [TestMethod]
        public void TestCircuit()
        {
            // Set up the inputs for the circuit.
            Node input1 = new InputHigh();
            Node input2 = new InputHigh();

            Node output = new OutputNode();

            Node node1 = new AndNode();
            Node node2 = new OrNode();
            Node node3 = new NotNode();

            // Connect the circuit

            output.addInput(node1);

            node1.addInput(node2);
            node1.addInput(node3);

            node2.addInput(input1);
            node2.addInput(input2);

            node3.addInput(input1);

            // node 2: true || true = true
            // node 3: !true = false
            // node 1: true && false = false
            Assert.AreEqual(false, output.Value);

            input1.Value = false;

            // node 2: false || true = true
            // node 3: !false = true
            // node 1: true && true = true
            Assert.AreEqual(true, output.Value);

            input1.Value = true;
            input2.Value = false;

            // node 2: true || false = true
            // node 3: !true = false
            // node 1: true && false = false
            Assert.AreEqual(false, output.Value);

            input1.Value = false;

            // node 2: false || false = false
            // node 3: !false = true
            // node 1: false && true = false 
            Assert.AreEqual(false, output.Value);
        }

        /// <summary>
        /// Tests if a looped circuit gives the expected value (null)
        /// </summary>
        [TestMethod]
        public void TestLoop()
        {
            Node node1 = new OrNode();
            Node node2 = new OrNode();
            Node output = new OutputNode();

            output.addInput(node1);
            node1.addInput(node2);
            node2.addInput(node1);

            Assert.AreEqual(null, output.Value);
        }

        /// <summary>
        /// Tests if a disconnected node gives the expected output (null)
        /// </summary>
        [TestMethod]
        public void TestDisconnected()
        {
            Node node = new AndNode();
            Node input = new InputHigh();
            Node output = new OutputNode();

            output.addInput(node);
            node.addInput(input);

            Assert.AreEqual(null, output.Value);
        }

        /// <summary>
        /// Tests a node with 2 inputs.
        /// </summary>
        /// <param name="nodeType">The type of the node to test</param>
        /// <param name="and">The expected value when both inputs are high.</param>
        /// <param name="or">The expected value when one input is high.</param>
        /// <param name="none">The expected value when both inputs are low.</param>
        private void TestNode(Type nodeType, bool and, bool or, bool none)
        {
            InputHigh inHigh = new InputHigh();
            InputLow inLow = new InputLow();

            Node nodeAnd = (Node)Activator.CreateInstance(nodeType);
            Node nodeOr = (Node)Activator.CreateInstance(nodeType);
            Node nodeOr2 = (Node)Activator.CreateInstance(nodeType);
            Node nodeNone = (Node)Activator.CreateInstance(nodeType);

            nodeAnd.addInput(inHigh);
            nodeAnd.addInput(inHigh);

            Assert.AreEqual(and, nodeAnd.Value);

            nodeOr.addInput(inHigh);
            nodeOr.addInput(inLow);

            Assert.AreEqual(or, nodeOr.Value);

            nodeOr2.addInput(inLow);
            nodeOr2.addInput(inHigh);

            Assert.AreEqual(or, nodeOr2.Value);

            nodeNone.addInput(inLow);
            nodeNone.addInput(inLow);

            Assert.AreEqual(none, nodeNone.Value);
        }

        /// <summary>
        /// Tests a node with 1 input
        /// </summary>
        /// <param name="nodeType">The type of the node to test</param>
        /// <param name="high">The expected value when the input is high.</param>
        /// <param name="low">The expected value when the input is low.</param>
        private void TestNode(Type nodeType, bool high, bool low)
        {
            InputHigh inHigh = new InputHigh();
            InputLow inLow = new InputLow();

            Node nodeHigh = (Node)Activator.CreateInstance(nodeType);
            Node nodeLow = (Node)Activator.CreateInstance(nodeType);

            nodeHigh.addInput(inHigh);

            Assert.AreEqual(high, nodeHigh.Value);

            nodeLow.addInput(inLow);

            Assert.AreEqual(low, nodeLow.Value);
        }
    }
}
