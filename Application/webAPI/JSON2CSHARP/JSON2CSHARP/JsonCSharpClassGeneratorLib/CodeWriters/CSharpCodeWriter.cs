using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Xamasoft.JsonClassGenerator.CodeWriters
{
    public class CSharpCodeWriter : ICodeWriter
    {
        public string FileExtension
        {
            get { return ".cs"; }
        }

        public string DisplayName
        {
            get { return "C#"; }
        }


        private const string NoRenameAttribute = "[Obfuscation(Feature = \"renaming\", Exclude = true)]";
        private const string NoPruneAttribute = "[Obfuscation(Feature = \"trigger\", Exclude = false)]";

        public string GetTypeName(JsonType type, IJsonClassGeneratorConfig config)
        {
            var arraysAsLists = !config.ExplicitDeserialization;

            switch (type.Type)
            {
                case JsonTypeEnum.Anything: return "object";
                case JsonTypeEnum.Array: return arraysAsLists ? "List<" + GetTypeName(type.InternalType, config) + ">" : GetTypeName(type.InternalType, config) + "[]";
                case JsonTypeEnum.Dictionary: return "Dictionary<string, " + GetTypeName(type.InternalType, config) + ">";
                case JsonTypeEnum.Boolean: return "bool";
                case JsonTypeEnum.Float: return "double";
                case JsonTypeEnum.Integer: return "int";
                case JsonTypeEnum.Long: return "long";
                case JsonTypeEnum.Date: return "DateTime";
                case JsonTypeEnum.NonConstrained: return "object";
                case JsonTypeEnum.NullableBoolean: return "bool?";
                case JsonTypeEnum.NullableFloat: return "double?";
                case JsonTypeEnum.NullableInteger: return "int?";
                case JsonTypeEnum.NullableLong: return "long?";
                case JsonTypeEnum.NullableDate: return "DateTime?";
                case JsonTypeEnum.NullableSomething: return "object";
                case JsonTypeEnum.Object: return type.AssignedName;
                case JsonTypeEnum.String: return "string";
                default: throw new System.NotSupportedException("Unsupported json type");
            }
        }


        private bool ShouldApplyNoRenamingAttribute(IJsonClassGeneratorConfig config)
        {
            return config.ApplyObfuscationAttributes && !config.ExplicitDeserialization && !config.UsePascalCase;
        }
        private bool ShouldApplyNoPruneAttribute(IJsonClassGeneratorConfig config)
        {
            return config.ApplyObfuscationAttributes && !config.ExplicitDeserialization && config.UseProperties;
        }

        public void WriteFileStart(IJsonClassGeneratorConfig config, TextWriter sw)
        {
            if (config.UseNamespaces)
            {
                foreach (var line in JsonClassGenerator.FileHeader)
                {
                    sw.WriteLine("// " + line);
                }
                sw.WriteLine();
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Collections.Generic;");
                if (ShouldApplyNoPruneAttribute(config) || ShouldApplyNoRenamingAttribute(config))
                    sw.WriteLine("using System.Reflection;");
                if (!config.ExplicitDeserialization && config.UsePascalCase)
                    sw.WriteLine("using Newtonsoft.Json;");
                sw.WriteLine("using Newtonsoft.Json.Linq;");
                if (config.ExplicitDeserialization)
                    sw.WriteLine("using JsonCSharpClassGenerator;");
                if (config.SecondaryNamespace != null && config.HasSecondaryClasses && !config.UseNestedClasses)
                {
                    sw.WriteLine("using {0};", config.SecondaryNamespace);
                }
            }

            if (config.UseNestedClasses)
            {
                sw.WriteLine("    {0} class {1}", config.InternalVisibility ? "internal" : "public", config.MainClass);
                sw.WriteLine("    {");
            }
        }

        public List<string> GetFileStart(IJsonClassGeneratorConfig config)
        {
            List<string> listTextStart = new List<string>();
            if (config.UseNamespaces)
            {
                //foreach (var line in JsonClassGenerator.FileHeader)
                //{
                //    //sw.WriteLine("// " + line);
                //    listTextStart.Add("// " +line);
                //}
                //sw.WriteLine();
                listTextStart.Add("");
                //sw.WriteLine("using System;");
                listTextStart.Add("using System");
                //sw.WriteLine("using System.Collections.Generic;");
                listTextStart.Add("using System.Collections.Generic;");
                if (ShouldApplyNoPruneAttribute(config) || ShouldApplyNoRenamingAttribute(config))
                {
                    //sw.WriteLine("using System.Reflection;");
                    listTextStart.Add("using System.Reflection;");
                }
                if (!config.ExplicitDeserialization && config.UsePascalCase)
                {
                    //sw.WriteLine("using Newtonsoft.Json;");
                    listTextStart.Add("using Newtonsoft.Json;");
                }
                //sw.WriteLine("using Newtonsoft.Json.Linq;");
                listTextStart.Add("using Newtonsoft.Json.Linq;");
                if (config.ExplicitDeserialization)
                {
                    //sw.WriteLine("using JsonCSharpClassGenerator;");
                    listTextStart.Add("using JsonCSharpClassGenerator;");
                }
                if (config.SecondaryNamespace != null && config.HasSecondaryClasses && !config.UseNestedClasses)
                {
                    //sw.WriteLine("using {0};", config.SecondaryNamespace);
                    listTextStart.Add(string.Format("using {0};", config.SecondaryNamespace));
                }
            }

            if (config.UseNestedClasses)
            {
                //sw.WriteLine("    {0} class {1}", config.InternalVisibility ? "internal" : "public", config.MainClass);
                listTextStart.Add(string.Format("    {0} class {1}", config.InternalVisibility ? "internal" : "public", config.MainClass));
                //sw.WriteLine("    {");
                listTextStart.Add("    {");
            }
            return listTextStart;
        }

        public void WriteFileEnd(IJsonClassGeneratorConfig config, TextWriter sw)
        {
            if (config.UseNestedClasses)
            {
                sw.WriteLine("    }");
            }
        }

        public List<string> GetFileEnd(IJsonClassGeneratorConfig config)
        {
            List<string> listFileEnd = new List<string>();
            if (config.UseNestedClasses)
            {
                //sw.WriteLine("    }");
                listFileEnd.Add("    }");
            }
            return listFileEnd;
        }


        public void WriteNamespaceStart(IJsonClassGeneratorConfig config, TextWriter sw, bool root)
        {
            sw.WriteLine();
            sw.WriteLine("namespace {0}", root && !config.UseNestedClasses ? config.Namespace : (config.SecondaryNamespace ?? config.Namespace));
            sw.WriteLine("{");
            sw.WriteLine();
        }
        public List<string> GetNamespaceStart(IJsonClassGeneratorConfig config, bool root)
        {
            List<string> listNamespaceStart = new List<string>();
            //sw.WriteLine();
            listNamespaceStart.Add("");
            //sw.WriteLine("namespace {0}", root && !config.UseNestedClasses ? config.Namespace : (config.SecondaryNamespace ?? config.Namespace));
            listNamespaceStart.Add(string.Format("namespace {0}", root && !config.UseNestedClasses ? config.Namespace : (config.SecondaryNamespace ?? config.Namespace)));
            //sw.WriteLine("{");
            listNamespaceStart.Add("{");
            //sw.WriteLine();
            listNamespaceStart.Add("");
            return listNamespaceStart;
        }

        public void WriteNamespaceEnd(IJsonClassGeneratorConfig config, TextWriter sw, bool root)
        {
            sw.WriteLine("}");
        }
        public List<string> GetNamespaceEnd(IJsonClassGeneratorConfig config, bool root)
        {
            List<string> listNamespaceEnd = new List<string>();
            //sw.WriteLine("}");
            listNamespaceEnd.Add("}");
            return listNamespaceEnd;
        }

        public void WriteClass(IJsonClassGeneratorConfig config, TextWriter sw, JsonType type)
        {
            var visibility = config.InternalVisibility ? "internal" : "public";



            if (config.UseNestedClasses)
            {
                if (!type.IsRoot)
                {
                    if (ShouldApplyNoRenamingAttribute(config)) sw.WriteLine("        " + NoRenameAttribute);
                    if (ShouldApplyNoPruneAttribute(config)) sw.WriteLine("        " + NoPruneAttribute);
                    sw.WriteLine("        {0} class {1}", visibility, type.AssignedName);
                    sw.WriteLine("        {");
                }
            }
            else
            {
                if (ShouldApplyNoRenamingAttribute(config)) sw.WriteLine("    " + NoRenameAttribute);
                if (ShouldApplyNoPruneAttribute(config)) sw.WriteLine("    " + NoPruneAttribute);
                sw.WriteLine("    {0} class {1}", visibility, type.AssignedName);
                sw.WriteLine("    {");
            }

            var prefix = config.UseNestedClasses && !type.IsRoot ? "            " : "        ";


            var shouldSuppressWarning = config.InternalVisibility && !config.UseProperties && !config.ExplicitDeserialization;
            if (shouldSuppressWarning)
            {
                sw.WriteLine("#pragma warning disable 0649");
                if (!config.UsePascalCase) sw.WriteLine();
            }

            if (type.IsRoot && config.ExplicitDeserialization) WriteStringConstructorExplicitDeserialization(config, sw, type, prefix);

            if (config.ExplicitDeserialization)
            {
                if (config.UseProperties) WriteClassWithPropertiesExplicitDeserialization(sw, type, prefix);
                else WriteClassWithFieldsExplicitDeserialization(sw, type, prefix);
            }
            else
            {
                WriteClassMembers(config, sw, type, prefix);
            }

            if (shouldSuppressWarning)
            {
                sw.WriteLine();
                sw.WriteLine("#pragma warning restore 0649");
                sw.WriteLine();
            }


            if (config.UseNestedClasses && !type.IsRoot)
                sw.WriteLine("        }");

            if (!config.UseNestedClasses)
                sw.WriteLine("    }");

            sw.WriteLine();


        }
        public List<string> GetClass(IJsonClassGeneratorConfig config, JsonType type)
        {
            var visibility = config.InternalVisibility ? "internal" : "public";
            List<string> listClass = new List<string>();


            if (config.UseNestedClasses)
            {
                if (!type.IsRoot)
                {
                    if (ShouldApplyNoRenamingAttribute(config))
                    {
                        //sw.WriteLine("        " + NoRenameAttribute);
                        listClass.Add("        " + NoRenameAttribute);
                    }
                    if (ShouldApplyNoPruneAttribute(config))
                    {
                        //sw.WriteLine("        " + NoPruneAttribute);
                        listClass.Add("        " + NoPruneAttribute);
                    }
                    //sw.WriteLine("        {0} class {1}", visibility, type.AssignedName);
                    listClass.Add(string.Format("        {0} class {1}", visibility, type.AssignedName));
                    //sw.WriteLine("        {");
                    listClass.Add("        {");
                }
            }
            else
            {
                if (ShouldApplyNoRenamingAttribute(config))
                {
                    //sw.WriteLine("    " + NoRenameAttribute);
                    listClass.Add("    " + NoRenameAttribute);
                }
                if (ShouldApplyNoPruneAttribute(config))
                {
                    //sw.WriteLine("    " + NoPruneAttribute);
                    listClass.Add("    " + NoPruneAttribute);
                }
                //sw.WriteLine("    {0} class {1}", visibility, type.AssignedName);
                listClass.Add(string.Format("    {0} class {1}", visibility, type.AssignedName));
                //sw.WriteLine("    {");
                listClass.Add("    {");
            }

            var prefix = config.UseNestedClasses && !type.IsRoot ? "            " : "        ";


            var shouldSuppressWarning = config.InternalVisibility && !config.UseProperties && !config.ExplicitDeserialization;
            if (shouldSuppressWarning)
            {
                //sw.WriteLine("#pragma warning disable 0649");
                listClass.Add("#pragma warning disable 0649");
                if (!config.UsePascalCase)
                {
                    //sw.WriteLine();
                    listClass.Add("");
                }
            }

            if (type.IsRoot && config.ExplicitDeserialization)
            {
                //WriteStringConstructorExplicitDeserialization(config, sw, type, prefix);
                List<string> listString = GetStringConstructorExplicitDeserialization(config, type, prefix);
                listClass.AddRange(listString);
            }

            if (config.ExplicitDeserialization)
            {
                if (config.UseProperties)
                {
                    //WriteClassWithPropertiesExplicitDeserialization(sw, type, prefix);
                    List<string> listString = GetClassWithPropertiesExplicitDeserialization(type, prefix);
                    listClass.AddRange(listString);
                }
                else
                {
                    //WriteClassWithFieldsExplicitDeserialization(sw, type, prefix);
                    List<string> listString = GetClassWithFieldsExplicitDeserialization(type, prefix);
                    listClass.AddRange(listString);
                }
            }
            else
            {
                //WriteClassMembers(config, sw, type, prefix);
                List<string> listString = GetClassMembers(config,type, prefix);
                listClass.AddRange(listString);
            }

            if (shouldSuppressWarning)
            {
                //sw.WriteLine();
                listClass.Add("");
                //sw.WriteLine("#pragma warning restore 0649");
                listClass.Add("#pragma warning restore 0649");
                //sw.WriteLine();
                listClass.Add("");
            }


            if (config.UseNestedClasses && !type.IsRoot)
            {
                //sw.WriteLine("        }");
                listClass.Add("        }");
            }

            if (!config.UseNestedClasses)
            {
                //sw.WriteLine("    }");
                listClass.Add("    }");
            }

            //sw.WriteLine();
            listClass.Add("");
            return listClass;

        }

        private DataTable CreateDataTable(IJsonClassGeneratorConfig config)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ColumnName", typeof(string));
            table.Columns.Add("Type", typeof(string));
            if (config.ExamplesInDocumentation)
            {
                table.Columns.Add("Example", typeof(string));
            }

            return table;
        }

        public DataTable GetDataTable(IJsonClassGeneratorConfig config, JsonType type)
        {
            var visibility = config.InternalVisibility ? "internal" : "public";
            //List<string> listClass = new List<string>();
            DataTable dt = CreateDataTable(config);

            if (config.UseNestedClasses)
            {
                if (!type.IsRoot)
                {
                    //if (ShouldApplyNoRenamingAttribute(config))
                    //{
                    //    //sw.WriteLine("        " + NoRenameAttribute);
                    //    listClass.Add("        " + NoRenameAttribute);
                    //}
                    //if (ShouldApplyNoPruneAttribute(config))
                    //{
                    //    //sw.WriteLine("        " + NoPruneAttribute);
                    //    listClass.Add("        " + NoPruneAttribute);
                    //}
                    //sw.WriteLine("        {0} class {1}", visibility, type.AssignedName);
                    //listClass.Add(string.Format("        {0} class {1}", visibility, type.AssignedName));
                    dt.TableName = type.AssignedName;
                    //sw.WriteLine("        {");
                    //listClass.Add("        {");
                }
            }
            else
            {
                //if (ShouldApplyNoRenamingAttribute(config))
                //{
                //    //sw.WriteLine("    " + NoRenameAttribute);
                //    listClass.Add("    " + NoRenameAttribute);
                //}
                //if (ShouldApplyNoPruneAttribute(config))
                //{
                //    //sw.WriteLine("    " + NoPruneAttribute);
                //    listClass.Add("    " + NoPruneAttribute);
                //}
                //sw.WriteLine("    {0} class {1}", visibility, type.AssignedName);
                //listClass.Add(string.Format("    {0} class {1}", visibility, type.AssignedName));
                dt.TableName = type.AssignedName;
                //sw.WriteLine("    {");
                //listClass.Add("    {");
            }

            var prefix = config.UseNestedClasses && !type.IsRoot ? "            " : "        ";


            //var shouldSuppressWarning = config.InternalVisibility && !config.UseProperties && !config.ExplicitDeserialization;
            //if (shouldSuppressWarning)
            //{
            //    //sw.WriteLine("#pragma warning disable 0649");
            //    listClass.Add("#pragma warning disable 0649");
            //    if (!config.UsePascalCase)
            //    {
            //        //sw.WriteLine();
            //        listClass.Add("");
            //    }
            //}

            //if (type.IsRoot && config.ExplicitDeserialization)
            //{
            //    //WriteStringConstructorExplicitDeserialization(config, sw, type, prefix);
            //    List<string> listString = GetStringConstructorExplicitDeserialization(config, sw, type, prefix);
            //    listClass.AddRange(listString);
            //}

            //if (config.ExplicitDeserialization)
            //{
            //    if (config.UseProperties)
            //    {
            //        //WriteClassWithPropertiesExplicitDeserialization(sw, type, prefix);
            //        List<string> listString = GetClassWithPropertiesExplicitDeserialization(sw, type, prefix);
            //        listClass.AddRange(listString);
            //    }
            //    else
            //    {
            //        //WriteClassWithFieldsExplicitDeserialization(sw, type, prefix);
            //        List<string> listString = GetClassWithFieldsExplicitDeserialization(sw, type, prefix);
            //        listClass.AddRange(listString);
            //    }
            //}
            //else
            {
                //WriteClassMembers(config, sw, type, prefix);
                GetRowsMembers(config, type, ref dt);
                //listClass.AddRange(listString);
            }

            //if (shouldSuppressWarning)
            //{
            //    //sw.WriteLine();
            //    listClass.Add("");
            //    //sw.WriteLine("#pragma warning restore 0649");
            //    listClass.Add("#pragma warning restore 0649");
            //    //sw.WriteLine();
            //    listClass.Add("");
            //}


            //if (config.UseNestedClasses && !type.IsRoot)
            //{
            //    //sw.WriteLine("        }");
            //    listClass.Add("        }");
            //}

            //if (!config.UseNestedClasses)
            //{
            //    //sw.WriteLine("    }");
            //    listClass.Add("    }");
            //}

            //sw.WriteLine();
            //listClass.Add("");
            return dt;

        }



        private void WriteClassMembers(IJsonClassGeneratorConfig config, TextWriter sw, JsonType type, string prefix)
        {
            foreach (var field in type.Fields)
            {
                if (config.UsePascalCase || config.ExamplesInDocumentation) sw.WriteLine();

                if (config.ExamplesInDocumentation)
                {
                    sw.WriteLine(prefix + "/// <summary>");
                    sw.WriteLine(prefix + "/// Examples: " + field.GetExamplesText());
                    sw.WriteLine(prefix + "/// </summary>");
                }

                if (config.UsePascalCase)
                {

                    sw.WriteLine(prefix + "[JsonProperty(\"{0}\")]", field.JsonMemberName);
                }

                if (config.UseProperties)
                {
                    sw.WriteLine(prefix + "public {0} {1} {{ get; set; }}", field.Type.GetTypeName(), field.MemberName);
                }
                else
                {
                    sw.WriteLine(prefix + "public {0} {1};", field.Type.GetTypeName(), field.MemberName);
                }
            }

        }

        private List<string> GetClassMembers(IJsonClassGeneratorConfig config, JsonType type, string prefix)
        {
            List<string> listClassMembers = new List<string>();
            foreach (var field in type.Fields)
            {
                if (config.UsePascalCase || config.ExamplesInDocumentation)
                {
                    //sw.WriteLine();
                    listClassMembers.Add("");
                }

                if (config.ExamplesInDocumentation)
                {
                    //sw.WriteLine(prefix + "/// <summary>");
                    listClassMembers.Add(prefix + "/// <summary>");
                    //sw.WriteLine(prefix + "/// Examples: " + field.GetExamplesText());
                    listClassMembers.Add(prefix + "/// Examples: " + field.GetExamplesText());
                    //sw.WriteLine(prefix + "/// </summary>");
                    listClassMembers.Add(prefix + "/// </summary>");
                }

                if (config.UsePascalCase)
                {

                    //sw.WriteLine(prefix + "[JsonProperty(\"{0}\")]", field.JsonMemberName);
                    listClassMembers.Add(string.Format(prefix + "[JsonProperty(\"{0}\")]", field.JsonMemberName));
                }

                if (config.UseProperties)
                {
                    //sw.WriteLine(prefix + "public {0} {1} {{ get; set; }}", field.Type.GetTypeName(), field.MemberName);
                    listClassMembers.Add(string.Format(prefix + "public {0} {1} {{ get; set; }}", field.Type.GetTypeName(), field.MemberName));
                }
                else
                {
                    //sw.WriteLine(prefix + "public {0} {1};", field.Type.GetTypeName(), field.MemberName);
                    listClassMembers.Add(string.Format(prefix + "public {0} {1};", field.Type.GetTypeName(), field.MemberName));
                }
            }
            return listClassMembers;
        }

        private void GetRowsMembers(IJsonClassGeneratorConfig config, JsonType type, ref DataTable dt)
        {
            //List<DataRow> listClassMembers = new List<DataRow>();
            foreach (var field in type.Fields)
            {
                DataRow row = dt.NewRow();
                //if (config.UsePascalCase || config.ExamplesInDocumentation)
                //{
                //    //sw.WriteLine();
                //    listClassMembers.Add("");
                //}

                if (config.ExamplesInDocumentation)
                {
                    ////sw.WriteLine(prefix + "/// <summary>");
                    //listClassMembers.Add(prefix + "/// <summary>");
                    ////sw.WriteLine(prefix + "/// Examples: " + field.GetExamplesText());
                    //listClassMembers.Add(prefix + "/// Examples: " + field.GetExamplesText());
                    row["Example"] =field.GetExamplesText();
                    ////sw.WriteLine(prefix + "/// </summary>");
                    //listClassMembers.Add(prefix + "/// </summary>");
                }

                if (config.UsePascalCase)
                {

                    //sw.WriteLine(prefix + "[JsonProperty(\"{0}\")]", field.JsonMemberName);
                    //listClassMembers.Add(string.Format(prefix + "[JsonProperty(\"{0}\")]", field.JsonMemberName));
                    row["ColumnName"] = field.JsonMemberName;
                }
                else
                {
                    row["ColumnName"] = field.MemberName;
                }

                //if (config.UseProperties)
                //{
                //    //sw.WriteLine(prefix + "public {0} {1} {{ get; set; }}", field.Type.GetTypeName(), field.MemberName);
                //    listClassMembers.Add(string.Format(prefix + "public {0} {1} {{ get; set; }}", field.Type.GetTypeName(), field.MemberName));
                //}
                //else
                //{
                //    //sw.WriteLine(prefix + "public {0} {1};", field.Type.GetTypeName(), field.MemberName);
                //    listClassMembers.Add(string.Format(prefix + "public {0} {1};", field.Type.GetTypeName(), field.MemberName));
                //}
                row["Type"] = field.Type.GetTypeName();
                dt.Rows.Add(row);
            }
            //return listClassMembers;
        }






        #region Code for (obsolete) explicit deserialization
        private void WriteClassWithPropertiesExplicitDeserialization(TextWriter sw, JsonType type, string prefix)
        {

            sw.WriteLine(prefix + "private JObject __jobject;");
            sw.WriteLine(prefix + "public {0}(JObject obj)", type.AssignedName);
            sw.WriteLine(prefix + "{");
            sw.WriteLine(prefix + "    this.__jobject = obj;");
            sw.WriteLine(prefix + "}");
            sw.WriteLine();

            foreach (var field in type.Fields)
            {

                string variable = null;
                if (field.Type.MustCache)
                {
                    variable = "_" + char.ToLower(field.MemberName[0]) + field.MemberName.Substring(1);
                    sw.WriteLine(prefix + "[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]");
                    sw.WriteLine(prefix + "private {0} {1};", field.Type.GetTypeName(), variable);
                }


                sw.WriteLine(prefix + "public {0} {1}", field.Type.GetTypeName(), field.MemberName);
                sw.WriteLine(prefix + "{");
                sw.WriteLine(prefix + "    get");
                sw.WriteLine(prefix + "    {");
                if (field.Type.MustCache)
                {
                    sw.WriteLine(prefix + "        if ({0} == null)", variable);
                    sw.WriteLine(prefix + "            {0} = {1};", variable, field.GetGenerationCode("__jobject"));
                    sw.WriteLine(prefix + "        return {0};", variable);
                }
                else
                {
                    sw.WriteLine(prefix + "        return {0};", field.GetGenerationCode("__jobject"));
                }
                sw.WriteLine(prefix + "    }");
                sw.WriteLine(prefix + "}");
                sw.WriteLine();

            }

        }

        private List<string> GetClassWithPropertiesExplicitDeserialization(JsonType type, string prefix)
        {
            List<string> listClassWithPropertues = new List<string>();
            //sw.WriteLine(prefix + "private JObject __jobject;");
            listClassWithPropertues.Add(prefix + "private JObject __jobject;");
            //sw.WriteLine(prefix + "public {0}(JObject obj)", type.AssignedName);
            listClassWithPropertues.Add(string.Format(prefix + "public {0}(JObject obj)", type.AssignedName));
            //sw.WriteLine(prefix + "{");
            listClassWithPropertues.Add(prefix + "{");
            //sw.WriteLine(prefix + "    this.__jobject = obj;");
            listClassWithPropertues.Add(prefix + "    this.__jobject = obj;");
            //sw.WriteLine(prefix + "}");
            listClassWithPropertues.Add(prefix + "}");
            //sw.WriteLine();
            listClassWithPropertues.Add("");

            foreach (var field in type.Fields)
            {

                string variable = null;
                if (field.Type.MustCache)
                {
                    variable = "_" + char.ToLower(field.MemberName[0]) + field.MemberName.Substring(1);
                    //sw.WriteLine(prefix + "[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]");
                    listClassWithPropertues.Add(prefix + "[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]");
                    //sw.WriteLine(prefix + "private {0} {1};", field.Type.GetTypeName(), variable);
                    listClassWithPropertues.Add(string.Format(prefix + "private {0} {1};", field.Type.GetTypeName(), variable));
                }


                //sw.WriteLine(prefix + "public {0} {1}", field.Type.GetTypeName(), field.MemberName);
                listClassWithPropertues.Add(string.Format(prefix + "public {0} {1}", field.Type.GetTypeName(), field.MemberName));
                //sw.WriteLine(prefix + "{");
                listClassWithPropertues.Add(prefix + "{");
                //sw.WriteLine(prefix + "    get");
                listClassWithPropertues.Add(prefix + "    get");
                //sw.WriteLine(prefix + "    {");
                listClassWithPropertues.Add(prefix + "    {");
                if (field.Type.MustCache)
                {
                    //sw.WriteLine(prefix + "        if ({0} == null)", variable);
                    listClassWithPropertues.Add(string.Format(prefix + "        if ({0} == null)", variable));
                    //sw.WriteLine(prefix + "            {0} = {1};", variable, field.GetGenerationCode("__jobject"));
                    listClassWithPropertues.Add(string.Format(prefix + "            {0} = {1};", variable, field.GetGenerationCode("__jobject")));
                    //sw.WriteLine(prefix + "        return {0};", variable);
                    listClassWithPropertues.Add(string.Format(prefix + "        return {0};", variable));
                }
                else
                {
                    //sw.WriteLine(prefix + "        return {0};", field.GetGenerationCode("__jobject"));
                    listClassWithPropertues.Add(string.Format(prefix + "        return {0};", field.GetGenerationCode("__jobject")));
                }
                //sw.WriteLine(prefix + "    }");
                listClassWithPropertues.Add(prefix + "    }");
                //sw.WriteLine(prefix + "}");
                listClassWithPropertues.Add(prefix + "}");
                //sw.WriteLine();
                listClassWithPropertues.Add("");

            }
            return listClassWithPropertues;
        }


        private void WriteStringConstructorExplicitDeserialization(IJsonClassGeneratorConfig config, TextWriter sw, JsonType type, string prefix)
        {
            sw.WriteLine();
            sw.WriteLine(prefix + "public {1}(string json)", config.InternalVisibility ? "internal" : "public", type.AssignedName);
            sw.WriteLine(prefix + "    : this(JObject.Parse(json))");
            sw.WriteLine(prefix + "{");
            sw.WriteLine(prefix + "}");
            sw.WriteLine();
        }

        private List<string> GetStringConstructorExplicitDeserialization(IJsonClassGeneratorConfig config, JsonType type, string prefix)
        {
            List<string> listString = new List<string>();
            //sw.WriteLine();
            listString.Add("");
            //sw.WriteLine(prefix + "public {1}(string json)", config.InternalVisibility ? "internal" : "public", type.AssignedName);
            listString.Add(string.Format(prefix + "public {1}(string json)", config.InternalVisibility ? "internal" : "public", type.AssignedName));
            //sw.WriteLine(prefix + "    : this(JObject.Parse(json))");
            listString.Add(prefix + "    : this(JObject.Parse(json))");
            //sw.WriteLine(prefix + "{");
            listString.Add(prefix + "{");
            //sw.WriteLine(prefix + "}");
            listString.Add(prefix + "}");
            //sw.WriteLine();
            listString.Add("");
            return listString;
        }

        private void WriteClassWithFieldsExplicitDeserialization(TextWriter sw, JsonType type, string prefix)
        {


            sw.WriteLine(prefix + "public {0}(JObject obj)", type.AssignedName);
            sw.WriteLine(prefix + "{");

            foreach (var field in type.Fields)
            {
                sw.WriteLine(prefix + "    this.{0} = {1};", field.MemberName, field.GetGenerationCode("obj"));

            }

            sw.WriteLine(prefix + "}");
            sw.WriteLine();

            foreach (var field in type.Fields)
            {
                sw.WriteLine(prefix + "public readonly {0} {1};", field.Type.GetTypeName(), field.MemberName);
            }
        }

        private List<string> GetClassWithFieldsExplicitDeserialization(JsonType type, string prefix)
        {

            List<string> listString = new List<string>();
            //sw.WriteLine(prefix + "public {0}(JObject obj)", type.AssignedName);
            listString.Add(string.Format(prefix + "public {0}(JObject obj)", type.AssignedName));
            //sw.WriteLine(prefix + "{");
            listString.Add(prefix + "{");

            foreach (var field in type.Fields)
            {
                //sw.WriteLine(prefix + "    this.{0} = {1};", field.MemberName, field.GetGenerationCode("obj"));
                listString.Add(string.Format(prefix + "    this.{0} = {1};", field.MemberName, field.GetGenerationCode("obj")));

            }

            //sw.WriteLine(prefix + "}");
            listString.Add(prefix + "}");
            //sw.WriteLine();
            listString.Add("");

            foreach (var field in type.Fields)
            {
                //sw.WriteLine(prefix + "public readonly {0} {1};", field.Type.GetTypeName(), field.MemberName);
                listString.Add(string.Format(prefix + "public readonly {0} {1};", field.Type.GetTypeName(), field.MemberName));
            }
            return listString;
        }
        #endregion

    }
}
