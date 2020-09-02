using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System;
using System.IO;
using TFrameWork.Core.Extension;

namespace TFrameWork.Core.EditorTool
{
    public sealed class ConfigObjClassCodeGenerator:ICodeGenerator
    {
        private StringBuilder m_Builder;
        public ConfigObjClassCodeGenerator()
        {
            m_Builder = new StringBuilder();
        }

        public void WriteHeader(string nameSpace, string className)
        {
            m_Builder.AppendAfterNewLine("using System;");
            m_Builder.AppendAfterNewLine("using TFrameWork.Core;");
            m_Builder.AppendLine();
            m_Builder.AppendFormatAfterNewLine("namespace {0}", nameSpace);
            m_Builder.AppendAfterNewLine("{");
            m_Builder.AppendFormatAfterNewLine("\tpublic sealed class {0}", className);
            m_Builder.AppendTabBeforeContent(1, "{");
        }

        public void WriteMember(string typeName, string fieldName)
        {
            m_Builder.AppendTabBeforeContentFormat(2, "public {0} {1};", typeName, fieldName).AppendLines(2);
        }

        public void WriteFunc(string func)
        {
            m_Builder.AppendTabBeforeContentFormat(2, "{0}", func).AppendLines(2);
        }

        public void WriteEnd()
        {
            m_Builder.AppendTabBeforeContent(1, "}");
            m_Builder.AppendAfterNewLine("}");
        }

        public void Save(string savePath)
        {
            File.WriteAllText(savePath, m_Builder.ToString());
            m_Builder = new StringBuilder();
        }
    }
}
