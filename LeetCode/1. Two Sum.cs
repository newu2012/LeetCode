using System;
using LeetCode;
using NUnit.Framework;

namespace LeetCode {
    public class TwoSumTask {
        public int[] TwoSum(int[] nums, int target) {
            var result = new[] {0, 0};
            for (var i = 0; i < nums.Length - 1; i++)
            for (var j = i + 1; j < nums.Length; j++)
                if (nums[i] + nums[j] == target) {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }

            return new[] {0, 0};
        }
    }
}

namespace LeetCodeTests {
    [TestFixture]
    public class TwoSumTests {
        [Test]
        public void Test1() {
            var task = new TwoSumTask();
            var result = task.TwoSum(new[] {2, 7, 11, 15}, 9);
            Assert.AreEqual(new[] {0, 1}, result);
        }
        
        [Test]
        public void Test2() {
            var task = new TwoSumTask();
            var result = task.TwoSum(new[] {3, 2, 4}, 6);
            Assert.AreEqual(new[] {1, 2}, result);
        }
        
        [Test]
        public void Test3() {
            var task = new TwoSumTask();
            var result = task.TwoSum(new[] {3, 3}, 6);
            Assert.AreEqual(new[] {0, 1}, result);
        }
    }
}