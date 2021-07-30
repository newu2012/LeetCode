using System;
using LeetCode;
using NUnit.Framework;

namespace LeetCode
{
    public class ContainerWithMostWaterTask {
        public int MaxArea(int[] height) {
            var leftMaxInd = 0;
            var rightMaxInd = 1;
            var leftMaxHeight = height[0];
            var rightMaxHeight = height[1];
            var maxWater = Math.Min(leftMaxHeight, rightMaxHeight);

            for (var cur = 2; cur < height.Length; cur++) {
                var newWater = (cur - leftMaxInd) * Math.Min(leftMaxHeight, height[cur]);
                if (newWater > maxWater) {
                    var maybeMore = (cur - rightMaxInd) * Math.Min(rightMaxHeight, height[cur]);
                    var maybeEvenMore = height.Length - 1 > cur ? Math.Min(height[cur], height[cur + 1]) : 0;
                    if (maybeMore >= newWater) {
                        leftMaxInd = rightMaxInd;
                        leftMaxHeight = rightMaxHeight;
                        maxWater = maybeMore;
                    } else if (maybeEvenMore > newWater) {
                        leftMaxInd = cur;
                        rightMaxInd = cur + 1;
                        leftMaxHeight = height[cur];
                        rightMaxHeight = height[cur + 1];
                    } else {
                        rightMaxInd = cur;
                        rightMaxHeight = height[cur];
                        maxWater = newWater;
                    }
                }
            }
        
            return maxWater;
        }
    }
}

namespace LeetCodeTests {
    [TestFixture]
    public class ContainerWithMostWaterTests {
        private ContainerWithMostWaterTask _task;

        [SetUp]
        public void SetUp() {
            _task = new ContainerWithMostWaterTask();
        }

        [Test]
        public void Example1() {
            Assert.AreEqual(49, _task.MaxArea(new[] {1, 8, 6, 2, 5, 4, 8, 3, 7}));
        }
        
        [Test]
        public void Example2() {
            Assert.AreEqual(1, _task.MaxArea(new []{1, 1}));
        }
        
        [Test]
        public void Example3() {
            Assert.AreEqual(16, _task.MaxArea(new []{4, 3, 2, 1, 4}));
        }
        
        [Test]
        public void Example4() {
            Assert.AreEqual(2, _task.MaxArea(new []{1, 2, 1}));
        }
        
        [Test]
        public void Test1() {
            Assert.AreEqual(9, _task.MaxArea(new []{3, 2, 1, 3}));
        }
        
        [Test]
        public void Test2() {
            Assert.AreEqual(4, _task.MaxArea(new []{1, 2, 4, 3}));
        }
        
        [Test]
        public void Test3() {
            Assert.AreEqual(8, _task.MaxArea(new []{1, 0, 0, 0, 0, 0, 0, 2, 2}));
        }
        
        [Test]
        public void Test4() {
            Assert.AreEqual(36, _task.MaxArea(new []{2, 3, 10, 5, 7, 8, 9}));
        }
        
        [Test]
        public void Test5() {
            Assert.AreEqual(24, _task.MaxArea(new []{1, 3, 2, 5, 25, 24, 5}));
        }
    }
}