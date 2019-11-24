namespace House2Invest
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    
    public static class DirectoryInfoExtensions
    {
        
        public static void CopyTo(DirectoryInfo source, string destDirectory, bool recursive)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (destDirectory == null)
            {
                throw new ArgumentNullException("destDirectory");
            }
            if (!source.Exists)
            {
                throw new DirectoryNotFoundException("Source directory not found: " + source.FullName);
            }
            DirectoryInfo info = new DirectoryInfo(destDirectory);
            if (!info.Exists)
            {
                info.Create();
            }
            foreach (FileInfo info2 in source.GetFiles())
            {
                info2.CopyTo(Path.Combine(info.FullName, info2.Name), true);
            }
            if (recursive)
            {
                foreach (DirectoryInfo info3 in source.GetDirectories())
                {
                    CopyTo(info3, Path.Combine(info.FullName, info3.Name), recursive);
                }
            }
        }
    }
}

