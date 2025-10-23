public class Solution 
{
    public int LongestBalancedSubarray(int[] nums) 
    {
        int maxLength = 0;
        
        // Try each possible starting point
        for (int start = 0; start < nums.Length; start++) 
        {
            HashSet<int> evenNums = new HashSet<int>();
            HashSet<int> oddNums = new HashSet<int>();
            
            // Extend the window
            for (int end = start; end < nums.Length; end++) 
            {
                // Add number to appropriate set
                if (nums[end] % 2 == 0) 
                {
                    evenNums.Add(nums[end]);
                } else 
                {
                    oddNums.Add(nums[end]);
                }
                
                // Check if current window is balanced
                if (evenNums.Count == oddNums.Count) 
                {
                    maxLength = Math.Max(maxLength, end - start + 1);
                }
            }
        }
        
        return maxLength;
    }
}









