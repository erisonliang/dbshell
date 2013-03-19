// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2013-03-19 20:36:18

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


  using DbShell.Driver.Common.DmlFramework;
using System.Globalization;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

public partial class NumberFilterParser : DbShellFilterAntlrParser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"MINUS", 
		"NUMBER", 
		"LT", 
		"GT", 
		"LE", 
		"GE", 
		"NE", 
		"EQ", 
		"T_NULL", 
		"T_NOT", 
		"COMMA", 
		"ENDLINE", 
		"N", 
		"U", 
		"L", 
		"O", 
		"T", 
		"DIGIT", 
		"WHITESPACE", 
		"A", 
		"B", 
		"C", 
		"D", 
		"E", 
		"F", 
		"G", 
		"H", 
		"I", 
		"J", 
		"K", 
		"M", 
		"P", 
		"Q", 
		"R", 
		"S", 
		"V", 
		"W", 
		"X", 
		"Y", 
		"Z"
    };

    public const int D = 26;
    public const int E = 27;
    public const int F = 28;
    public const int GE = 9;
    public const int G = 29;
    public const int LT = 6;
    public const int A = 23;
    public const int B = 24;
    public const int C = 25;
    public const int L = 18;
    public const int M = 34;
    public const int N = 16;
    public const int O = 19;
    public const int H = 30;
    public const int I = 31;
    public const int J = 32;
    public const int K = 33;
    public const int NUMBER = 5;
    public const int U = 17;
    public const int T = 20;
    public const int W = 40;
    public const int WHITESPACE = 22;
    public const int V = 39;
    public const int Q = 36;
    public const int P = 35;
    public const int S = 38;
    public const int R = 37;
    public const int MINUS = 4;
    public const int EOF = -1;
    public const int Y = 42;
    public const int X = 41;
    public const int Z = 43;
    public const int COMMA = 14;
    public const int T_NULL = 12;
    public const int GT = 7;
    public const int ENDLINE = 15;
    public const int DIGIT = 21;
    public const int EQ = 11;
    public const int T_NOT = 13;
    public const int LE = 8;
    public const int NE = 10;

    // delegates
    // delegators



        public NumberFilterParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public NumberFilterParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return NumberFilterParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "NumberFilter.g"; }
    }


    public class negative_number_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "negative_number"
    // NumberFilter.g:14:1: negative_number : MINUS num1= NUMBER ;
    public NumberFilterParser.negative_number_return negative_number() // throws RecognitionException [1]
    {   
        NumberFilterParser.negative_number_return retval = new NumberFilterParser.negative_number_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num1 = null;
        IToken MINUS1 = null;

        object num1_tree=null;
        object MINUS1_tree=null;

        try 
    	{
            // NumberFilter.g:14:16: ( MINUS num1= NUMBER )
            // NumberFilter.g:15:3: MINUS num1= NUMBER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	MINUS1=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_negative_number43); 
            		MINUS1_tree = (object)adaptor.Create(MINUS1);
            		adaptor.AddChild(root_0, MINUS1_tree);

            	num1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_negative_number47); 
            		num1_tree = (object)adaptor.Create(num1);
            		adaptor.AddChild(root_0, num1_tree);

            	 Push(-Decimal.Parse(((num1 != null) ? num1.Text : null), CultureInfo.InvariantCulture)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "negative_number"

    public class positive_number_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "positive_number"
    // NumberFilter.g:17:1: positive_number : num1= NUMBER ;
    public NumberFilterParser.positive_number_return positive_number() // throws RecognitionException [1]
    {   
        NumberFilterParser.positive_number_return retval = new NumberFilterParser.positive_number_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num1 = null;

        object num1_tree=null;

        try 
    	{
            // NumberFilter.g:17:16: (num1= NUMBER )
            // NumberFilter.g:18:3: num1= NUMBER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	num1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_positive_number63); 
            		num1_tree = (object)adaptor.Create(num1);
            		adaptor.AddChild(root_0, num1_tree);

            	 Push(Decimal.Parse(((num1 != null) ? num1.Text : null), CultureInfo.InvariantCulture)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "positive_number"

    public class number_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "number"
    // NumberFilter.g:20:1: number : ( positive_number | negative_number );
    public NumberFilterParser.number_return number() // throws RecognitionException [1]
    {   
        NumberFilterParser.number_return retval = new NumberFilterParser.number_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.positive_number_return positive_number2 = default(NumberFilterParser.positive_number_return);

        NumberFilterParser.negative_number_return negative_number3 = default(NumberFilterParser.negative_number_return);



        try 
    	{
            // NumberFilter.g:20:7: ( positive_number | negative_number )
            int alt1 = 2;
            int LA1_0 = input.LA(1);

            if ( (LA1_0 == NUMBER) )
            {
                alt1 = 1;
            }
            else if ( (LA1_0 == MINUS) )
            {
                alt1 = 2;
            }
            else 
            {
                NoViableAltException nvae_d1s0 =
                    new NoViableAltException("", 1, 0, input);

                throw nvae_d1s0;
            }
            switch (alt1) 
            {
                case 1 :
                    // NumberFilter.g:21:3: positive_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_positive_number_in_number76);
                    	positive_number2 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number2.Tree);

                    }
                    break;
                case 2 :
                    // NumberFilter.g:21:21: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_number80);
                    	negative_number3 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number3.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "number"

    public class interval_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "interval"
    // NumberFilter.g:23:1: interval : number MINUS num2= NUMBER ;
    public NumberFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        NumberFilterParser.interval_return retval = new NumberFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num2 = null;
        IToken MINUS5 = null;
        NumberFilterParser.number_return number4 = default(NumberFilterParser.number_return);


        object num2_tree=null;
        object MINUS5_tree=null;

        try 
    	{
            // NumberFilter.g:23:10: ( number MINUS num2= NUMBER )
            // NumberFilter.g:24:1: number MINUS num2= NUMBER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_number_in_interval89);
            	number4 = number();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, number4.Tree);
            	MINUS5=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval91); 
            		MINUS5_tree = (object)adaptor.Create(MINUS5);
            		adaptor.AddChild(root_0, MINUS5_tree);

            	num2=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_interval95); 
            		num2_tree = (object)adaptor.Create(num2);
            		adaptor.AddChild(root_0, num2_tree);


            	        var left = Pop<decimal>();var right=Decimal.Parse(((num2 != null) ? num2.Text : null), CultureInfo.InvariantCulture);
            	        Conditions.Add(new DmlfBetweenCondition
            	            {
            	                Expr = ColumnValue,
            	                LowerBound = new DmlfLiteralExpression{Value = left},
            	                UpperBound = new DmlfLiteralExpression{Value = right},
            	            });


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "interval"

    public class element_no_negative_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "element_no_negative"
    // NumberFilter.g:34:1: element_no_negative : ( positive_number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL );
    public NumberFilterParser.element_no_negative_return element_no_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_no_negative_return retval = new NumberFilterParser.element_no_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken LT8 = null;
        IToken GT9 = null;
        IToken LE10 = null;
        IToken GE11 = null;
        IToken NE12 = null;
        IToken EQ13 = null;
        IToken T_NULL14 = null;
        IToken T_NOT15 = null;
        IToken T_NULL16 = null;
        NumberFilterParser.number_return num1 = default(NumberFilterParser.number_return);

        NumberFilterParser.positive_number_return positive_number6 = default(NumberFilterParser.positive_number_return);

        NumberFilterParser.interval_return interval7 = default(NumberFilterParser.interval_return);


        object LT8_tree=null;
        object GT9_tree=null;
        object LE10_tree=null;
        object GE11_tree=null;
        object NE12_tree=null;
        object EQ13_tree=null;
        object T_NULL14_tree=null;
        object T_NOT15_tree=null;
        object T_NULL16_tree=null;

        try 
    	{
            // NumberFilter.g:34:20: ( positive_number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL )
            int alt2 = 10;
            alt2 = dfa2.Predict(input);
            switch (alt2) 
            {
                case 1 :
                    // NumberFilter.g:35:3: positive_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_positive_number_in_element_no_negative107);
                    	positive_number6 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number6.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:36:5: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element_no_negative116);
                    	interval7 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval7.Tree);

                    }
                    break;
                case 3 :
                    // NumberFilter.g:37:5: LT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT8=(IToken)Match(input,LT,FOLLOW_LT_in_element_no_negative122); 
                    		LT8_tree = (object)adaptor.Create(LT8);
                    		adaptor.AddChild(root_0, LT8_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative126);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<"); 

                    }
                    break;
                case 4 :
                    // NumberFilter.g:38:5: GT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT9=(IToken)Match(input,GT,FOLLOW_GT_in_element_no_negative135); 
                    		GT9_tree = (object)adaptor.Create(GT9);
                    		adaptor.AddChild(root_0, GT9_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative139);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), ">"); 

                    }
                    break;
                case 5 :
                    // NumberFilter.g:39:5: LE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE10=(IToken)Match(input,LE,FOLLOW_LE_in_element_no_negative148); 
                    		LE10_tree = (object)adaptor.Create(LE10);
                    		adaptor.AddChild(root_0, LE10_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative152);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<="); 

                    }
                    break;
                case 6 :
                    // NumberFilter.g:40:5: GE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE11=(IToken)Match(input,GE,FOLLOW_GE_in_element_no_negative161); 
                    		GE11_tree = (object)adaptor.Create(GE11);
                    		adaptor.AddChild(root_0, GE11_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative165);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), ">="); 

                    }
                    break;
                case 7 :
                    // NumberFilter.g:41:5: NE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE12=(IToken)Match(input,NE,FOLLOW_NE_in_element_no_negative174); 
                    		NE12_tree = (object)adaptor.Create(NE12);
                    		adaptor.AddChild(root_0, NE12_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative178);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<>"); 

                    }
                    break;
                case 8 :
                    // NumberFilter.g:42:5: EQ num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ13=(IToken)Match(input,EQ,FOLLOW_EQ_in_element_no_negative187); 
                    		EQ13_tree = (object)adaptor.Create(EQ13);
                    		adaptor.AddChild(root_0, EQ13_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative191);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "="); 

                    }
                    break;
                case 9 :
                    // NumberFilter.g:43:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL14=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative200); 
                    		T_NULL14_tree = (object)adaptor.Create(T_NULL14);
                    		adaptor.AddChild(root_0, T_NULL14_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 10 :
                    // NumberFilter.g:44:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT15=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element_no_negative208); 
                    		T_NOT15_tree = (object)adaptor.Create(T_NOT15);
                    		adaptor.AddChild(root_0, T_NOT15_tree);

                    	T_NULL16=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative210); 
                    		T_NULL16_tree = (object)adaptor.Create(T_NULL16);
                    		adaptor.AddChild(root_0, T_NULL16_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "element_no_negative"

    public class element_maybe_negative_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "element_maybe_negative"
    // NumberFilter.g:47:1: element_maybe_negative : ( negative_number | element_no_negative );
    public NumberFilterParser.element_maybe_negative_return element_maybe_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_maybe_negative_return retval = new NumberFilterParser.element_maybe_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.negative_number_return negative_number17 = default(NumberFilterParser.negative_number_return);

        NumberFilterParser.element_no_negative_return element_no_negative18 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:47:23: ( negative_number | element_no_negative )
            int alt3 = 2;
            alt3 = dfa3.Predict(input);
            switch (alt3) 
            {
                case 1 :
                    // NumberFilter.g:48:3: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_element_maybe_negative226);
                    	negative_number17 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number17.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:49:5: element_no_negative
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_element_no_negative_in_element_maybe_negative234);
                    	element_no_negative18 = element_no_negative();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element_no_negative18.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "element_maybe_negative"

    public class factor_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "factor"
    // NumberFilter.g:51:1: factor : element_maybe_negative ( element_no_negative )* ;
    public NumberFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        NumberFilterParser.factor_return retval = new NumberFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.element_maybe_negative_return element_maybe_negative19 = default(NumberFilterParser.element_maybe_negative_return);

        NumberFilterParser.element_no_negative_return element_no_negative20 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:51:8: ( element_maybe_negative ( element_no_negative )* )
            // NumberFilter.g:52:3: element_maybe_negative ( element_no_negative )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_element_maybe_negative_in_factor246);
            	element_maybe_negative19 = element_maybe_negative();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, element_maybe_negative19.Tree);
            	// NumberFilter.g:52:26: ( element_no_negative )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= MINUS && LA4_0 <= T_NOT)) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // NumberFilter.g:52:26: element_no_negative
            			    {
            			    	PushFollow(FOLLOW_element_no_negative_in_factor248);
            			    	element_no_negative20 = element_no_negative();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element_no_negative20.Tree);

            			    }
            			    break;

            			default:
            			    goto loop4;
            	    }
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "factor"

    public class list_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "list"
    // NumberFilter.g:54:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public NumberFilterParser.list_return list() // throws RecognitionException [1]
    {   
        NumberFilterParser.list_return retval = new NumberFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA22 = null;
        IToken ENDLINE23 = null;
        IToken ENDLINE25 = null;
        NumberFilterParser.factor_return factor21 = default(NumberFilterParser.factor_return);

        NumberFilterParser.factor_return factor24 = default(NumberFilterParser.factor_return);


        object COMMA22_tree=null;
        object ENDLINE23_tree=null;
        object ENDLINE25_tree=null;

        try 
    	{
            // NumberFilter.g:54:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // NumberFilter.g:55:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list259);
            	factor21 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor21.Tree);
            	// NumberFilter.g:55:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt7 = 2;
            	    alt7 = dfa7.Predict(input);
            	    switch (alt7) 
            		{
            			case 1 :
            			    // NumberFilter.g:55:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// NumberFilter.g:55:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt6 = 2;
            			    	int LA6_0 = input.LA(1);

            			    	if ( (LA6_0 == COMMA) )
            			    	{
            			    	    alt6 = 1;
            			    	}
            			    	else if ( (LA6_0 == ENDLINE) )
            			    	{
            			    	    alt6 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d6s0 =
            			    	        new NoViableAltException("", 6, 0, input);

            			    	    throw nvae_d6s0;
            			    	}
            			    	switch (alt6) 
            			    	{
            			    	    case 1 :
            			    	        // NumberFilter.g:55:13: COMMA
            			    	        {
            			    	        	COMMA22=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list264); 
            			    	        		COMMA22_tree = (object)adaptor.Create(COMMA22);
            			    	        		adaptor.AddChild(root_0, COMMA22_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // NumberFilter.g:55:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// NumberFilter.g:55:21: ( ( ENDLINE )+ )
            			    	        	// NumberFilter.g:55:22: ( ENDLINE )+
            			    	        	{
            			    	        		// NumberFilter.g:55:22: ( ENDLINE )+
            			    	        		int cnt5 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt5 = 2;
            			    	        		    int LA5_0 = input.LA(1);

            			    	        		    if ( (LA5_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt5 = 1;
            			    	        		    }


            			    	        		    switch (alt5) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // NumberFilter.g:55:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE23=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list269); 
            			    	        				    		ENDLINE23_tree = (object)adaptor.Create(ENDLINE23);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE23_tree);


            			    	        				    }
            			    	        				    break;

            			    	        				default:
            			    	        				    if ( cnt5 >= 1 ) goto loop5;
            			    	        			            EarlyExitException eee5 =
            			    	        			                new EarlyExitException(5, input);
            			    	        			            throw eee5;
            			    	        		    }
            			    	        		    cnt5++;
            			    	        		} while (true);

            			    	        		loop5:
            			    	        			;	// Stops C# compiler whining that label 'loop5' has no statements


            			    	        	}


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list276);
            			    	factor24 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor24.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	// NumberFilter.g:55:67: ( ENDLINE )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);

            	    if ( (LA8_0 == ENDLINE) )
            	    {
            	        alt8 = 1;
            	    }


            	    switch (alt8) 
            		{
            			case 1 :
            			    // NumberFilter.g:55:67: ENDLINE
            			    {
            			    	ENDLINE25=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list282); 
            			    		ENDLINE25_tree = (object)adaptor.Create(ENDLINE25);
            			    		adaptor.AddChild(root_0, ENDLINE25_tree);


            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "list"

    public class expr_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr"
    // NumberFilter.g:57:1: expr : list ;
    public NumberFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        NumberFilterParser.expr_return retval = new NumberFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.list_return list26 = default(NumberFilterParser.list_return);



        try 
    	{
            // NumberFilter.g:57:5: ( list )
            // NumberFilter.g:57:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr292);
            	list26 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list26.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expr"

    // Delegated rules


   	protected DFA2 dfa2;
   	protected DFA3 dfa3;
   	protected DFA7 dfa7;
	private void InitializeCyclicDFAs()
	{
    	this.dfa2 = new DFA2(this);
    	this.dfa3 = new DFA3(this);
    	this.dfa7 = new DFA7(this);
	}

    const string DFA2_eotS =
        "\x12\uffff";
    const string DFA2_eofS =
        "\x01\uffff\x01\x0c\x0b\uffff\x01\x02\x01\uffff\x01\x0c\x01\uffff"+
        "\x01\x02";
    const string DFA2_minS =
        "\x02\x04\x09\uffff\x01\x05\x01\uffff\x01\x04\x01\x05\x01\x04\x01"+
        "\x05\x01\x04";
    const string DFA2_maxS =
        "\x01\x0d\x01\x0f\x09\uffff\x01\x05\x01\uffff\x01\x0f\x01\x05\x01"+
        "\x0f\x01\x05\x01\x0f";
    const string DFA2_acceptS =
        "\x02\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
        "\x08\x01\x09\x01\x0a\x01\uffff\x01\x01\x05\uffff";
    const string DFA2_specialS =
        "\x12\uffff}>";
    static readonly string[] DFA2_transitionS = {
            "\x01\x02\x01\x01\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
            "\x08\x01\x09\x01\x0a",
            "\x01\x0b\x0b\x0c",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x0d",
            "",
            "\x01\x0e\x0b\x02",
            "\x01\x0f",
            "\x01\x10\x0b\x0c",
            "\x01\x11",
            "\x01\x0e\x0b\x02"
    };

    static readonly short[] DFA2_eot = DFA.UnpackEncodedString(DFA2_eotS);
    static readonly short[] DFA2_eof = DFA.UnpackEncodedString(DFA2_eofS);
    static readonly char[] DFA2_min = DFA.UnpackEncodedStringToUnsignedChars(DFA2_minS);
    static readonly char[] DFA2_max = DFA.UnpackEncodedStringToUnsignedChars(DFA2_maxS);
    static readonly short[] DFA2_accept = DFA.UnpackEncodedString(DFA2_acceptS);
    static readonly short[] DFA2_special = DFA.UnpackEncodedString(DFA2_specialS);
    static readonly short[][] DFA2_transition = DFA.UnpackEncodedStringArray(DFA2_transitionS);

    protected class DFA2 : DFA
    {
        public DFA2(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 2;
            this.eot = DFA2_eot;
            this.eof = DFA2_eof;
            this.min = DFA2_min;
            this.max = DFA2_max;
            this.accept = DFA2_accept;
            this.special = DFA2_special;
            this.transition = DFA2_transition;

        }

        override public string Description
        {
            get { return "34:1: element_no_negative : ( positive_number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL );"; }
        }

    }

    const string DFA3_eotS =
        "\x0b\uffff";
    const string DFA3_eofS =
        "\x03\uffff\x01\x04\x02\uffff\x01\x02\x01\uffff\x01\x04\x01\uffff"+
        "\x01\x02";
    const string DFA3_minS =
        "\x01\x04\x01\x05\x01\uffff\x01\x04\x01\uffff\x01\x05\x01\x04\x01"+
        "\x05\x01\x04\x01\x05\x01\x04";
    const string DFA3_maxS =
        "\x01\x0d\x01\x05\x01\uffff\x01\x0f\x01\uffff\x01\x05\x01\x0f\x01"+
        "\x05\x01\x0f\x01\x05\x01\x0f";
    const string DFA3_acceptS =
        "\x02\uffff\x01\x02\x01\uffff\x01\x01\x06\uffff";
    const string DFA3_specialS =
        "\x0b\uffff}>";
    static readonly string[] DFA3_transitionS = {
            "\x01\x01\x09\x02",
            "\x01\x03",
            "",
            "\x01\x05\x0b\x04",
            "",
            "\x01\x06",
            "\x01\x07\x0b\x02",
            "\x01\x08",
            "\x01\x09\x0b\x04",
            "\x01\x0a",
            "\x01\x07\x0b\x02"
    };

    static readonly short[] DFA3_eot = DFA.UnpackEncodedString(DFA3_eotS);
    static readonly short[] DFA3_eof = DFA.UnpackEncodedString(DFA3_eofS);
    static readonly char[] DFA3_min = DFA.UnpackEncodedStringToUnsignedChars(DFA3_minS);
    static readonly char[] DFA3_max = DFA.UnpackEncodedStringToUnsignedChars(DFA3_maxS);
    static readonly short[] DFA3_accept = DFA.UnpackEncodedString(DFA3_acceptS);
    static readonly short[] DFA3_special = DFA.UnpackEncodedString(DFA3_specialS);
    static readonly short[][] DFA3_transition = DFA.UnpackEncodedStringArray(DFA3_transitionS);

    protected class DFA3 : DFA
    {
        public DFA3(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 3;
            this.eot = DFA3_eot;
            this.eof = DFA3_eof;
            this.min = DFA3_min;
            this.max = DFA3_max;
            this.accept = DFA3_accept;
            this.special = DFA3_special;
            this.transition = DFA3_transition;

        }

        override public string Description
        {
            get { return "47:1: element_maybe_negative : ( negative_number | element_no_negative );"; }
        }

    }

    const string DFA7_eotS =
        "\x04\uffff";
    const string DFA7_eofS =
        "\x02\x02\x02\uffff";
    const string DFA7_minS =
        "\x01\x0e\x01\x04\x02\uffff";
    const string DFA7_maxS =
        "\x02\x0f\x02\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA7_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x03\x01\x01",
            "\x0a\x03\x01\uffff\x01\x01",
            "",
            ""
    };

    static readonly short[] DFA7_eot = DFA.UnpackEncodedString(DFA7_eotS);
    static readonly short[] DFA7_eof = DFA.UnpackEncodedString(DFA7_eofS);
    static readonly char[] DFA7_min = DFA.UnpackEncodedStringToUnsignedChars(DFA7_minS);
    static readonly char[] DFA7_max = DFA.UnpackEncodedStringToUnsignedChars(DFA7_maxS);
    static readonly short[] DFA7_accept = DFA.UnpackEncodedString(DFA7_acceptS);
    static readonly short[] DFA7_special = DFA.UnpackEncodedString(DFA7_specialS);
    static readonly short[][] DFA7_transition = DFA.UnpackEncodedStringArray(DFA7_transitionS);

    protected class DFA7 : DFA
    {
        public DFA7(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 7;
            this.eot = DFA7_eot;
            this.eof = DFA7_eof;
            this.min = DFA7_min;
            this.max = DFA7_max;
            this.accept = DFA7_accept;
            this.special = DFA7_special;
            this.transition = DFA7_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 55:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_MINUS_in_negative_number43 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_negative_number47 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NUMBER_in_positive_number63 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_positive_number_in_number76 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_number80 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_interval89 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval91 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_interval95 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_positive_number_in_element_no_negative107 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element_no_negative116 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element_no_negative122 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative126 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element_no_negative135 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative139 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element_no_negative148 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative152 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element_no_negative161 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative165 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element_no_negative174 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative178 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element_no_negative187 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative191 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative200 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element_no_negative208 = new BitSet(new ulong[]{0x0000000000001000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative210 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_element_maybe_negative226 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_element_maybe_negative234 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_maybe_negative_in_factor246 = new BitSet(new ulong[]{0x0000000000003FF2UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_factor248 = new BitSet(new ulong[]{0x0000000000003FF2UL});
    public static readonly BitSet FOLLOW_factor_in_list259 = new BitSet(new ulong[]{0x000000000000C002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list264 = new BitSet(new ulong[]{0x0000000000003FF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list269 = new BitSet(new ulong[]{0x000000000000BFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list276 = new BitSet(new ulong[]{0x000000000000C002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list282 = new BitSet(new ulong[]{0x0000000000008002UL});
    public static readonly BitSet FOLLOW_list_in_expr292 = new BitSet(new ulong[]{0x0000000000000002UL});

}
