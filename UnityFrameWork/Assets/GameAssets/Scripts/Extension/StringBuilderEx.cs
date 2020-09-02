using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TFrameWork.Core.Extension
{
    public static class StringBuilderEx
    {
        public static StringBuilder AppendAfterNewLine(this StringBuilder builder, string content)
        {
            builder.Append(content).AppendLine();
            return builder;
        }

        public static StringBuilder AppendFormatAfterNewLine(this StringBuilder builder, string format, params object[] args)
        {
            builder.AppendFormat(format, args).AppendLine();
            return builder;
        }

        public static StringBuilder AppendTabBeforeContent(this StringBuilder builder, int tabCount, string content)
        {
            for (int i = 0; i < tabCount; i++)
            {
                builder.Append("\t");
            }
            builder.Append(content).AppendLine();
            return builder;
        }

        public static StringBuilder AppendTabBeforeContentFormat(this StringBuilder builder, int tabCount, string format, params object[] args)
        {
            for (int i = 0; i < tabCount; i++)
            {
                builder.Append("\t");
            }
            builder.AppendFormat(format, args);
            return builder;
        }

        public static StringBuilder AppendLines(this StringBuilder builder, int count)
        {
            for (int i = 0; i < count; i++)
            {
                builder.AppendLine();
            }
            return builder;
        }
    }
}

