using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFrameWork.Core.EditorTool
{
    public interface ICodeGenerator
    {
        void WriteHeader(string nameSpace, string className);

        void WriteMember(string fieldType, string fieldName);

        void WriteEnd();

        void Save(string savePath);

        void WriteFunc(string func);
        
    }

}
