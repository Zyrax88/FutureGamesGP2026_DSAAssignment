using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static EmployeesData;

namespace Utils {
    public static class TreeUtil
    {

        private class Node {
            public DateTime value;
            public Node left;
            public Node right;
            public Node(DateTime myValue) {
                value = myValue;
            }
        }

        public class Tree {

            Node root;
            Node[] nodes;

            Tree(DateTime[] inArray) {
                root = new Node(inArray[(inArray.Length/2)-1]);
                nodes[0] = root;
                Create(inArray);
            }

            public void Create(DateTime[] e) {

                Node current;
                Node[] nodes;

                if(root == null) {
                    root = new Node(e[(e.Length/2)-1]);
                }

                nodes = new Node[e.Length];
                nodes[0] = root;

                current = root;

                int index = 0;
                while(index <= e.Length) {
                    current = root;
                    while(current != null) {
                        if(e[index] > current.value) {
                            current = current.right;
                        }

                        if(e[index] < current.value) {
                            current = current.left;
                        }
                    }
                    nodes[index] = new Node(e[index]);
                }

                foreach(Node node in nodes) {
                    Debug.Log(node.value);
                }
                
            }
        }


        private class BSTNode {
            private DateTime value;
            public BSTNode? left;
            public BSTNode? right;

            public BSTNode(DateTime inValue)
            {
                this.value = inValue;
            }

            public DateTime GetValue() {
                return value;
            }
        }
        public class BSTTree {
            private BSTNode root;

            public BSTTree(DateTime inRoot) {
                root = new BSTNode(inRoot);
            }

            public void Insert(DateTime inValue) {
                BSTNode node = new BSTNode(inValue);
                BSTNode? currentNode = root;
                BSTNode? lastParent = root;

                while(currentNode != null) {
                    if(inValue < currentNode.GetValue()) {
                        lastParent = currentNode;
                        currentNode = currentNode.left;
                    }
                    else {
                        lastParent = currentNode;
                        currentNode = currentNode.right;
                    }
                }

                if(inValue < lastParent.GetValue()) {
                    lastParent.left = node;
                }
                else {
                    lastParent.right = node;
                }
            }

            public string Search(DateTime timeToSearch) {
                if(root == null) {
                    throw new Exception(ExceptionMessages.Common_IsNull_Failed);
                }

                BSTNode? currentNode = root;

                GenericStack<BSTNode> stack = new GenericStack<BSTNode>();

                while(currentNode != null || stack.GetCount() > 0) {
                    while(currentNode != null) {
                        if(currentNode.GetValue() == timeToSearch) {
                            return "Found the DateTime";
                        }
                        stack.Push(currentNode);
                        currentNode = currentNode.left;
                    }
                    currentNode = stack.Pop();
                    currentNode = currentNode.right;

                    if(currentNode != null) {
                        if(currentNode.GetValue() == timeToSearch) {
                            return "Found the DateTime";
                        }
                    }

                }
                return "Did not find the DateTime";
                
            }

        }
    }
}
