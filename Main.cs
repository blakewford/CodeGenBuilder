using System;
using System.Diagnostics;
using System.IO;
using System.Text;

public class CodeGenBuilder
{
    private static readonly string CLANG_C_PATH = "/llvm-project/clang/test/CodeGen/";
    private static readonly string CLANG_CXX_PATH = "/llvm-project/clang/test/CodeGenCXX/";

    private static string[] mTests = {
"./2007-05-08-PCH.c",
"./2007-08-01-LoadStoreAlign.c",
"./x86_64-profiling-keep-fp.c",
"./2009-05-22-callingconv.c",
"./pr5406.c",
"./blocksignature.c",
"./debug-info-block-decl.c",
"./debug-info-no-inline-line-tables.c",
"./noduplicate-cxx11-test.cpp",
"./2004-03-15-SimpleIndirectGoto.c",
"./builtin-expect.c",
"./2010-02-18-Dbg-VectorType.c",
"./kr-style-block.c",
"./split-debug-single-file.c",
"./stackrealign-main.c",
"./2009-10-20-GlobalDebug.c",
"./no-junk-ftrunc.c",
"./alloca.c",
"./2007-09-27-ComplexIntCompare.c",
"./emit-summary-index.c",
"./capture-complex-expr-in-block.c",
"./available-externally-hidden.cpp",
"./2008-07-22-packed-bitfield-access.c",
"./arm-apcs-zerolength-bitfield.c",
"./func-in-block.c",
"./blocks-1.c",
"./stdcall-fastcall.c",
"./arm-aapcs-zerolength-bitfield.c",
"./2002-02-18-64bitConstant.c",
"./annotations-builtin.c",
"./attr-mode-enums.c",
"./enum.c",
"./split-lto-unit.c",
"./2009-02-13-zerosize-union-field.c",
"./ms_this.cpp",
"./shared-string-literals.c",
"./overloadable.c",
"./funccall.c",
"./2002-04-07-SwitchStmt.c",
"./indirect-goto.c",
"./mips-constraint-regs.c",
"./debug-info-codeview-unnamed.c",
"./2002-07-14-MiscTests3.c",
"./2009-01-05-BlockInlining.c",
"./writable-strings.c",
"./asan-static-odr.cpp",
"./constructor-attribute.c",
"./blockstret.c",
"./debug-info-static-const-fp.c",
"./split-debug-filename.c",
"./debug-info-gline-tables-only2.c",
"./mandel.c",
"./mandel.c",
"./builtins.c",
"./2009-04-23-dbg.c",
"./string-literal.c",
"./blocks.c",
"./microsoft-call-conv-x64.c",
"./debug-info-scope.c",
"./ms_struct-bitfield-init.c",
"./2010-02-15-DbgStaticVar.c",
"./2002-08-02-UnionTest.c",
"./split-stacks.c",
"./pascal-wchar-string.c",
"./char-literal.c",
"./thinlto-split-dwarf.c",
"./volatile.c",
"./no-ident-version.c",
"./string-literal-short-wstring.c",
"./wchar-const.c",
"./debug-prefix-map.c",
"./debug-info-version.c",
"./label-array-aggregate-init.c",
"./dllexport-1.c",
"./denormalfpmode.c",
"./thin_link_bitcode.c",
"./dwarf-version.c",
"./noexceptionsfpmath.c",
"./complex.c",
"./2007-06-15-AnnotateAttribute.c",
"./predefined-expr.c",
"./microsoft-call-conv.c",
"./asan-globals-odr.cpp",
"./mcount.c",
"./clear_cache.c",
"./vlt_to_pointer.c",
"./builtin-cpu-supports.c",
"./block-3.c",
"./nousejumptable.c",
"./fold-const-declref.c",
"./annotations-field.c",
"./eh-aggregated-inits.cpp",
"./ms-inline-asm-return.cpp",
"./ptr-to-member-function.cpp",
"./array-value-initialize.cpp",
"./cast-conversion.cpp",
"./nested-base-member-access.cpp",
"./mangle.cpp",
"./constructor-init.cpp",
"./constructor-conversion.cpp",
//"./lpad-linetable.cpp",
"./copy-constructor-synthesis.cpp",
"./debug-info-artificial-arg.cpp",
"./predefined-expr-sizeof.cpp",
"./mangle-this-cxx11.cpp",
"./multi-dim-operator-new.cpp",
"./virtual-base-destructor-call.cpp",
"./debug-info-dllimport-base-class.cpp",
//"./pr29160.cpp",
"./default-constructor-for-members.cpp",
"./predefined-expr.cpp",
"./microsoft-abi-cdecl-method-sret.cpp",
"./cp-blocks-linetables.cpp",
"./debug-info-method2.cpp",
"./auto-variable-template.cpp",
"./vararg-conversion-ctor.cpp",
"./debug-info-line-if.cpp",
"./debug-info-codeview-unnamed.cpp",
"./debug-info-nrvo.cpp",
"./vla-lambda-capturing.cpp",
"./float128-declarations.cpp",
"./constructor-for-array-members.cpp",
"./switch-case-folding-2.cpp",
"./eh-aggregated-inits-unwind.cpp",
"./sanitize-dtor-fn-attribute.cpp",
"./empty-classes.cpp",
"./aarch64-aapcs-zerolength-bitfield.cpp",
"./rtti-layout.cpp",
"./overload-binop-implicitconvert.cpp",
"./temp-order.cpp",
"./reference-in-blocks.cpp",
"./static-init-1.cpp",
"./debug-info-class.cpp",
"./reference-in-block-args.cpp",
"./microsoft-uuidof-mangling.cpp",
"./debug-info-loops.cpp",
"./debug-info-template-align.cpp",
"./2004-03-08-ReinterpretCastCopy.cpp",
"./2010-05-12-PtrToMember-Dbg.cpp",
"./copy-constructor-elim.cpp",
"./conversion-function.cpp",
"./constructor-default-arg.cpp",
"./copy-assign-synthesis.cpp",
//"./2009-04-23-bool2.cpp",
"./debug-info-fwd-ref.cpp",
"./2007-01-02-UnboundedArray.cpp",
//"./debug-info-globalinit.cpp",
//"./vla-consruct.cpp",
"./cxx11-trivial-initializer-struct.cpp",
"./global-array-destruction.cpp",
//"./cast-to-ref-bool.cpp",
"./array-construction.cpp",
"./copy-assign-synthesis-1.cpp",
"./ptr-to-datamember.cpp",
"./dllimport-template-sdm.cpp",
"./destructor-calls.cpp",
"./convert-to-fptr.cpp",
//"./debug-info-explicit-cast.cpp",
"./float16-declarations.cpp",
"./constructor-template.cpp",
"./union-tbaa2.cpp",
"./ARM/exception-alignment.cpp",
"./eh-aggregate-copy-destroy.cpp",
"./block-capture.cpp",
"./decl-ref-init.cpp",
"./cfi-ms-vbase-derived-cast.cpp",
"./main-norecurse.cpp",
"./array-operator-delete-call.cpp",
"./mangle-ms.cpp",
//"./ubsan-type-checks.cpp",
"./switch-case-folding-1.cpp",
"./conditional-gnu-ext.cpp",
"./conditional-gnu-ext.cpp",
//"./attr-x86-no_caller_saved_registers.cpp",
"./attr-cleanup.cpp",
"./mangle-template.cpp",
//"./exception-spec-decay.cpp",
"./ms_wide_predefined_expr.cpp",
"./switch-case-folding.cpp",
"./stmtexpr.cpp",
"./regcall.cpp",
"./cxx1y-variable-template-linkage.cpp",
"./2009-03-17-dbg.cpp",
"./builtins.cpp",
"./friend-redecl.cpp",
"./mangle-exprs.cpp",
"./linetable-fnbegin.cpp",
"./2010-05-11-alwaysinlineinstantiation.cpp",
"./ubsan-coroutines.cpp",
"./call-arg-zero-temp.cpp",
"./trivial-constructor-init.cpp",
"./microsoft-abi-byval-vararg.cpp",
"./2010-06-22-BitfieldInit.cpp",
"./microsoft-abi-byval-sret.cpp",
"./pr18635.cpp",
"./PR28523.cpp",
"./ms-property.cpp",
"./default_calling_conv.cpp",
"./template-dependent-bind-temporary.cpp",
"./block.cpp",
//"./vlt_to_reference.cpp",
"./mangle-mingw.cpp",
"./microsoft-abi-try-throw.cpp",
"./debug-info-static-member.cpp",
    };

    private enum Architecture
    {
        x86_64,
        aarch64
    }

    private static Architecture GetPlatform()
    {
        ProcessStartInfo info = new ProcessStartInfo("lscpu");
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;

        Process process = Process.Start(info);
        process.WaitForExit();

        string output = process.StandardOutput.ReadToEnd();
        string[] lines = output.Split((new []{'\r', '\n'}));

        return (Architecture)Enum.Parse(typeof(Architecture), lines[0].Split(':')[1].Trim());
    }

    public static void Main(string[] args)
    {
        string Home = Environment.GetEnvironmentVariable("HOME");
        string Compiler = Home;        
        if(GetPlatform() == Architecture.aarch64)
        {
            Compiler = "/media/usb";
        }

        Console.WriteLine("Name Ticks Instructions Identified segreg flgctrl inout string break cond shftrot decimal binary conver stack control branch bit logical arith datamov");
        foreach(string test in mTests)
        {
            File.Delete("test");
            Process process = Process.Start(Compiler + "/build/bin/clang++", Home + CLANG_C_PATH + test + " -o test -include catch.h");
            process.WaitForExit();

            bool built = false;
            if(!File.Exists("test"))
            {
                process = Process.Start(Compiler + "/build/bin/clang++", Home + CLANG_CXX_PATH + test + " -o test -include catch.h");
                process.WaitForExit();
                built = File.Exists("test");
                if(!File.Exists("test"))
                {
                    process = Process.Start(Compiler + "/build/bin/clang++", Home + CLANG_C_PATH + test + " -o test -include catch-args.h");
                    process.WaitForExit();
                    built = File.Exists("test");
                    if(!File.Exists("test"))
                    {
                        process = Process.Start(Compiler + "/build/bin/clang++", Home + CLANG_CXX_PATH + test + " -o test -include catch-args.h");
                        process.WaitForExit();
                        built = File.Exists("test");
                    }
                }
            }
            else
            {
                built = true;
            }

            if(!built) continue;

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "test").WaitForExit();
            watch.Stop();

            StringBuilder arguments = new StringBuilder();
            arguments.Append("--execute " + " " + AppDomain.CurrentDomain.BaseDirectory + "test --statistics");
            ProcessStartInfo info = new ProcessStartInfo(Home + "/portauthority/src/cpp/authority", arguments.ToString());
            info.WorkingDirectory = Home + "/portauthority/src/cpp";
            Console.Write(test + " " + watch.ElapsedTicks);
            process = Process.Start(info);
            process.WaitForExit();
        }

        return;
    }
};
