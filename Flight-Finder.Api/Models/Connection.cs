//namespace Flight_Finder.Api.Models
//{
//    public class Connection
//    {
//        void DepthFirstIterative(T start, T endNode)
//        {
//            var visited = new LinkedList<T>();
//            var stack = new Stack<T>();

//            stack.Push(start);

//            while (stack.Count != 0)
//            {
//                var current = stack.Pop();

//                if (visited.Contains(current))
//                    continue;

//                visited.AddLast(current);

//                var neighbours = AdjacentNodes(current);

//                foreach (var neighbour in neighbours)
//                {
//                    if (visited.Contains(neighbour))
//                        continue;

//                    if (neighbour.Equals(endNode))
//                    {
//                        visited.AddLast(neighbour);
//                        printPath(visited));
//                        visited.RemoveLast();
//                        break;
//                    }
//                }

//                bool isPushed = false;
//                foreach (var neighbour in neighbours.Reverse())
//                {
//                    if (neighbour.Equals(endNode) || visited.Contains(neighbour) || stack.Contains(neighbour))
//                    {
//                        continue;
//                    }

//                    isPushed = true;
//                    stack.Push(neighbour);
//                }

//                if (!isPushed)
//                    visited.RemoveLast();
//            }
//        }

//    }
//}
