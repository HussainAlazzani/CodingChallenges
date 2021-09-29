using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public class KthLargest
    {
        private int _k;
        private int _r;
        private List<int> list = new List<int>();

        public KthLargest(int k, int[] nums)
        {
            _k = k;
            if (nums.Length >= k)
            {
                Array.Sort(nums);

                for (int i = nums.Length - k; i < nums.Length; i++)
                {
                    list.Add(nums[i]);
                }
                _r = list.Min();
            }
            else if (nums.Length < k && nums.Length > 0)
            {
                list = nums.ToList();
                _r = list.Min();
            }
        }

        public int Add(int val)
        {
            if (list.Count < _k)
            {
                list.Add(val);
                _r = list.Min();
            }
            else
            {
                if (val > _r)
                {
                    list.Remove(_r);
                    list.Add(val);
                    _r = list.Min();
                }
            }
            return _r;

        }
    }
}