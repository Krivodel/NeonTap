using UnityEngine;
using UnityEditor;
using DG.DOTweenEditor;
using System.Collections.Generic;

namespace Krivodeling.Animation.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TransformAnimator))]
    public class TransformAnimatorEditor : UnityEditor.Editor
    {
        #region Variables
        private new TransformAnimator target;
        private new SerializedObject serializedObject;

        private SerializedProperty PlayAtStart;
        private SerializedProperty InstantAction;

        private SerializedProperty Animation;
        private SerializedProperty Move, Rotate, Scale;

        private SerializedProperty MoveEnabled;
        private SerializedProperty MoveAnimationType;
        private SerializedProperty MoveLoopType;
        private SerializedProperty MoveNumberOfLoops;
        private SerializedProperty MoveStartDelay, MoveDuration, MoveVibrato, MoveElasticity;
        private SerializedProperty MoveUseCustomFromAndTo;
        private SerializedProperty MoveFrom, MoveTo, MoveBy;
        private SerializedProperty MoveIgnoreTimeScale;
        private SerializedProperty MoveSpeedBased;
        private SerializedProperty MoveEaseType;
        private SerializedProperty MoveEase;
        private SerializedProperty MoveAnimationCurve;
        private SerializedProperty MoveOnStart, MoveOnComplete;

        private SerializedProperty RotateEnabled;
        private SerializedProperty RotateAnimationType;
        private SerializedProperty RotateRotateMode;
        private SerializedProperty RotateLoopType;
        private SerializedProperty RotateNumberOfLoops;
        private SerializedProperty RotateStartDelay, RotateDuration, RotateVibrato, RotateElasticity;
        private SerializedProperty RotateUseCustomFromAndTo;
        private SerializedProperty RotateFrom, RotateTo, RotateBy;
        private SerializedProperty RotateIgnoreTimeScale;
        private SerializedProperty RotateSpeedBased;
        private SerializedProperty RotateEaseType;
        private SerializedProperty RotateEase;
        private SerializedProperty RotateAnimationCurve;
        private SerializedProperty RotateOnStart, RotateOnComplete;

        private SerializedProperty ScaleEnabled;
        private SerializedProperty ScaleAnimationType;
        private SerializedProperty ScaleLoopType;
        private SerializedProperty ScaleNumberOfLoops;
        private SerializedProperty ScaleStartDelay, ScaleDuration, ScaleVibrato, ScaleElasticity;
        private SerializedProperty ScaleUseCustomFromAndTo;
        private SerializedProperty ScaleFrom, ScaleTo, ScaleBy;
        private SerializedProperty ScaleIgnoreTimeScale;
        private SerializedProperty ScaleSpeedBased;
        private SerializedProperty ScaleEaseType;
        private SerializedProperty ScaleEase;
        private SerializedProperty ScaleAnimationCurve;
        private SerializedProperty ScaleOnStart, ScaleOnComplete;

        private bool drawMove, drawRotate, drawScale;
        private bool drawMoveEvents, drawRotateEvents, drawScaleEvents;
        #endregion

        #region Methods
        private void OnEnable()
        {
            target = (TransformAnimator)base.target;
            serializedObject = base.serializedObject;

            PlayAtStart = serializedObject.FindProperty("PlayAtStart");
            InstantAction = serializedObject.FindProperty("InstantAction");

            Animation = serializedObject.FindProperty("Animation");
            Move = Animation.FindPropertyRelative("Move");
            Rotate = Animation.FindPropertyRelative("Rotate");
            Scale = Animation.FindPropertyRelative("Scale");

            MoveEnabled = Move.FindPropertyRelative("Enabled");
            MoveAnimationType = Move.FindPropertyRelative("AnimationType");
            MoveLoopType = Move.FindPropertyRelative("LoopType");
            MoveNumberOfLoops = Move.FindPropertyRelative("NumberOfLoops");
            MoveUseCustomFromAndTo = Move.FindPropertyRelative("UseCustomFromAndTo");
            MoveStartDelay = Move.FindPropertyRelative("StartDelay");
            MoveDuration = Move.FindPropertyRelative("Duration");
            MoveVibrato = Move.FindPropertyRelative("Vibrato");
            MoveElasticity = Move.FindPropertyRelative("Elasticity");
            MoveFrom = Move.FindPropertyRelative("From");
            MoveTo = Move.FindPropertyRelative("To");
            MoveBy = Move.FindPropertyRelative("By");
            MoveIgnoreTimeScale = Move.FindPropertyRelative("IgnoreTimeScale");
            MoveSpeedBased = Move.FindPropertyRelative("SpeedBased");
            MoveEaseType = Move.FindPropertyRelative("EaseType");
            MoveEase = Move.FindPropertyRelative("Ease");
            MoveAnimationCurve = Move.FindPropertyRelative("AnimationCurve");
            MoveOnStart = serializedObject.FindProperty("onStartMove");
            MoveOnComplete = serializedObject.FindProperty("onCompleteMove");

            RotateEnabled = Rotate.FindPropertyRelative("Enabled");
            RotateAnimationType = Rotate.FindPropertyRelative("AnimationType");
            RotateRotateMode = Rotate.FindPropertyRelative("RotateMode");
            RotateLoopType = Rotate.FindPropertyRelative("LoopType");
            RotateNumberOfLoops = Rotate.FindPropertyRelative("NumberOfLoops");
            RotateStartDelay = Rotate.FindPropertyRelative("StartDelay");
            RotateDuration = Rotate.FindPropertyRelative("Duration");
            RotateVibrato = Rotate.FindPropertyRelative("Vibrato");
            RotateElasticity = Rotate.FindPropertyRelative("Elasticity");
            RotateUseCustomFromAndTo = Rotate.FindPropertyRelative("UseCustomFromAndTo");
            RotateFrom = Rotate.FindPropertyRelative("From");
            RotateTo = Rotate.FindPropertyRelative("To");
            RotateBy = Rotate.FindPropertyRelative("By");
            RotateIgnoreTimeScale = Rotate.FindPropertyRelative("IgnoreTimeScale");
            RotateSpeedBased = Rotate.FindPropertyRelative("SpeedBased");
            RotateEaseType = Rotate.FindPropertyRelative("EaseType");
            RotateEase = Rotate.FindPropertyRelative("Ease");
            RotateAnimationCurve = Rotate.FindPropertyRelative("AnimationCurve");
            RotateOnStart = serializedObject.FindProperty("onStartRotate");
            RotateOnComplete = serializedObject.FindProperty("onCompleteRotate");

            ScaleEnabled = Scale.FindPropertyRelative("Enabled");
            ScaleAnimationType = Scale.FindPropertyRelative("AnimationType");
            ScaleLoopType = Scale.FindPropertyRelative("LoopType");
            ScaleNumberOfLoops = Scale.FindPropertyRelative("NumberOfLoops");
            ScaleStartDelay = Scale.FindPropertyRelative("StartDelay");
            ScaleDuration = Scale.FindPropertyRelative("Duration");
            ScaleVibrato = Scale.FindPropertyRelative("Vibrato");
            ScaleElasticity = Scale.FindPropertyRelative("Elasticity");
            ScaleUseCustomFromAndTo = Scale.FindPropertyRelative("UseCustomFromAndTo");
            ScaleFrom = Scale.FindPropertyRelative("From");
            ScaleTo = Scale.FindPropertyRelative("To");
            ScaleBy = Scale.FindPropertyRelative("By");
            ScaleIgnoreTimeScale = Scale.FindPropertyRelative("IgnoreTimeScale");
            ScaleSpeedBased = Scale.FindPropertyRelative("SpeedBased");
            ScaleEaseType = Scale.FindPropertyRelative("EaseType");
            ScaleEase = Scale.FindPropertyRelative("Ease");
            ScaleAnimationCurve = Scale.FindPropertyRelative("AnimationCurve");
            ScaleOnStart = serializedObject.FindProperty("onStartScale");
            ScaleOnComplete = serializedObject.FindProperty("onCompleteScale");

            drawMove = EditorPrefs.GetBool("TransformAnimator:" + "drawMove");
            drawRotate = EditorPrefs.GetBool("TransformAnimator:" + "drawRotate");
            drawScale = EditorPrefs.GetBool("TransformAnimator:" + "drawScale");
            drawMoveEvents = EditorPrefs.GetBool("TransformAnimator:" + "drawMoveEvents");
            drawRotateEvents = EditorPrefs.GetBool("TransformAnimator:" + "drawRotateEvents");
            drawScaleEvents = EditorPrefs.GetBool("TransformAnimator:" + "drawScaleEvents");
        }

        private void OnDisable()
        {
            EditorPrefs.SetBool("TransformAnimator:" + "drawMove", drawMove);
            EditorPrefs.SetBool("TransformAnimator:" + "drawRotate", drawRotate);
            EditorPrefs.SetBool("TransformAnimator:" + "drawScale", drawScale);
            EditorPrefs.SetBool("TransformAnimator:" + "drawMoveEvents", drawMoveEvents);
            EditorPrefs.SetBool("TransformAnimator:" + "drawRotateEvents", drawRotateEvents);
            EditorPrefs.SetBool("TransformAnimator:" + "drawScaleEvents", drawScaleEvents);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            Undo.RecordObject(target, "TransformAnimator:" + target.name);

            DrawGeneral();
            DrawMove();
            DrawRotate();
            DrawScale();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawGeneral()
        {
            Color guiColor = GUI.color;

            EditorGUILayout.BeginHorizontal();
            {
                GUI.color = Color.cyan;

                if (GUILayout.Button("Preview"))
                {
                    DOTweenEditorPreview.Stop(true);

                    target.UpdateStartValues();

                    if (target.Animation.Move.Enabled)
                    {
                        switch (target.Animation.Move.AnimationType)
                        {
                            case AnimationType.Default:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.MoveDefaultTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Move.UseCustomFromAndTo ? target.Animation.Move.From : target.StartPosition,
                                        target.Animation.Move.UseCustomFromAndTo ? target.Animation.Move.To : target.Animation.Move.By),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.Loop:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.MoveLoopTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Move.UseCustomFromAndTo ? target.Animation.Move.From : target.StartPosition
                                        ),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.Punch:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.MovePunchTween(
                                        target.transform,
                                        target.Animation
                                        ),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.State:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.MoveStateTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Move.UseCustomFromAndTo ? target.Animation.Move.From : target.StartPosition
                                        ),
                                    true, true, false
                                    );
                                break;
                        }
                    }

                    if (target.Animation.Rotate.Enabled)
                    {
                        switch (target.Animation.Rotate.AnimationType)
                        {
                            case AnimationType.Default:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.RotateDefaultTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Rotate.UseCustomFromAndTo ? target.Animation.Rotate.From : target.StartRotation,
                                        target.Animation.Rotate.UseCustomFromAndTo ? target.Animation.Rotate.To : target.Animation.Rotate.By),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.Loop:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.RotateLoopTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Rotate.UseCustomFromAndTo ? target.Animation.Rotate.From : target.StartRotation
                                        ),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.Punch:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.RotatePunchTween(
                                        target.transform,
                                        target.Animation
                                        ),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.State:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.RotateStateTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Rotate.UseCustomFromAndTo ? target.Animation.Rotate.From : target.StartRotation
                                        ),
                                    true, true, false
                                    );
                                break;
                        }
                    }

                    if (target.Animation.Scale.Enabled)
                    {
                        switch (target.Animation.Scale.AnimationType)
                        {
                            case AnimationType.Default:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.ScaleDefaultTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Scale.UseCustomFromAndTo ? target.Animation.Scale.From : target.StartScale,
                                        target.Animation.Scale.UseCustomFromAndTo ? target.Animation.Scale.To : target.Animation.Rotate.By),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.Loop:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.ScaleLoopTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Scale.UseCustomFromAndTo ? target.Animation.Scale.From : target.StartScale,
                                        target.Animation.Scale.UseCustomFromAndTo ? target.Animation.Scale.To : target.Animation.Scale.By
                                        ),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.Punch:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.ScalePunchTween(
                                        target.transform,
                                        target.Animation
                                        ),
                                    true, true, false
                                    );
                                break;
                            case AnimationType.State:
                                DOTweenEditorPreview.PrepareTweenForPreview(
                                    TransformAnimatorUtility.ScaleStateTween(
                                        target.transform,
                                        target.Animation,
                                        target.Animation.Scale.UseCustomFromAndTo ? target.Animation.Scale.From : target.StartScale
                                        ),
                                    true, true, false
                                    );
                                break;
                        }
                    }

                    DOTweenEditorPreview.Start();
                }

                GUI.color = Color.magenta;

                if (GUILayout.Button("Stop"))
                {
                    DOTweenEditorPreview.Stop();
                    target.ResetToStartValues();
                }

                GUI.color = Color.yellow;

                if (GUILayout.Button("Presets"))
                    TransformAnimatorPresetsWindow.Open(target);
            }
            EditorGUILayout.EndHorizontal();

            GUI.color = guiColor;

            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            {
                PlayAtStart.boolValue = EditorGUILayout.ToggleLeft("Play At Start", PlayAtStart.boolValue);
                InstantAction.boolValue = EditorGUILayout.ToggleLeft("Instant Action", InstantAction.boolValue);
            }
            EditorGUILayout.EndHorizontal();
        }

        private void DrawMove()
        {
            Color guiColor = GUI.color;

            EditorGUILayout.Space();

            GUI.color = MoveEnabled.boolValue ? Color.green : Color.red;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                EditorGUILayout.BeginHorizontal();
                {
                    MoveEnabled.boolValue = EditorGUILayout.ToggleLeft("", MoveEnabled.boolValue, GUILayout.Width(30f));

                    drawMove = EditorGUILayout.Foldout(drawMove, "Move", true);

                    GUI.color = guiColor;
                }
                EditorGUILayout.EndHorizontal();

                if (drawMove)
                {
                    GUI.color = MoveEnabled.boolValue ? Color.green : Color.red;
                    EditorGUILayout.BeginVertical();
                    {
                        GUI.color = guiColor;

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            EditorGUILayout.PropertyField(MoveAnimationType);

                            if (target.Animation.Move.AnimationType == AnimationType.Loop)
                            {
                                EditorGUILayout.BeginHorizontal();

                                EditorGUILayout.BeginVertical();

                                EditorGUILayout.PrefixLabel("Loop Type");
                                MoveLoopType.enumValueIndex = EditorGUILayout.Popup(MoveLoopType.enumValueIndex, MoveLoopType.enumDisplayNames);

                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();

                                EditorGUILayout.PrefixLabel("Number Of Loops");
                                MoveNumberOfLoops.intValue = EditorGUILayout.IntField(MoveNumberOfLoops.intValue);

                                EditorGUILayout.EndVertical();

                                EditorGUILayout.EndHorizontal();
                            }

                            EditorGUILayout.Space();

                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Start Delay");
                                    MoveStartDelay.floatValue = EditorGUILayout.FloatField(MoveStartDelay.floatValue);
                                }
                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Duration");
                                    MoveDuration.floatValue = EditorGUILayout.FloatField(MoveDuration.floatValue);
                                }
                                EditorGUILayout.EndVertical();
                            }
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            {
                                if (target.Animation.Move.AnimationType == AnimationType.Punch)
                                {
                                    EditorGUILayout.BeginVertical();

                                    EditorGUILayout.PrefixLabel("Vibrato");
                                    MoveVibrato.intValue = EditorGUILayout.IntField(MoveVibrato.intValue);

                                    EditorGUILayout.EndVertical();

                                    EditorGUILayout.BeginVertical();

                                    EditorGUILayout.PrefixLabel("Elasticity");
                                    MoveElasticity.floatValue = EditorGUILayout.FloatField(MoveElasticity.floatValue);

                                    EditorGUILayout.EndVertical();
                                }
                            }
                            EditorGUILayout.EndHorizontal();
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            MoveUseCustomFromAndTo.boolValue = EditorGUILayout.ToggleLeft("Use Custom From and To", MoveUseCustomFromAndTo.boolValue);

                            EditorGUILayout.Space();

                            if (MoveUseCustomFromAndTo.boolValue)
                            {
                                EditorGUILayout.PropertyField(MoveFrom);
                                EditorGUILayout.PropertyField(MoveTo);
                            }
                            else
                                EditorGUILayout.PropertyField(MoveBy);
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                        {
                            MoveIgnoreTimeScale.boolValue = EditorGUILayout.ToggleLeft("Ignore Time Scale", MoveIgnoreTimeScale.boolValue);
                            MoveSpeedBased.boolValue = EditorGUILayout.ToggleLeft("Speed Based", MoveSpeedBased.boolValue);
                        }
                        EditorGUILayout.EndHorizontal();

                        if (target.Animation.Move.AnimationType != AnimationType.Punch)
                        {
                            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Ease Type");
                                    MoveEaseType.enumValueIndex = EditorGUILayout.Popup(MoveEaseType.enumValueIndex, MoveEaseType.enumDisplayNames);
                                }
                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();
                                {
                                    if (target.Animation.Move.EaseType == EaseType.Ease)
                                    {
                                        EditorGUILayout.PrefixLabel("Ease");
                                        MoveEase.enumValueIndex = EditorGUILayout.Popup(MoveEase.enumValueIndex, MoveEase.enumDisplayNames);
                                    }
                                    else
                                    {
                                        EditorGUILayout.PrefixLabel("Curve");
                                        MoveAnimationCurve.animationCurveValue = EditorGUILayout.CurveField(MoveAnimationCurve.animationCurveValue);
                                    }
                                }
                                EditorGUILayout.EndVertical();
                            }
                            EditorGUILayout.EndHorizontal();
                        }

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            EditorGUILayout.BeginHorizontal();
                            {
                                GUI.color = Color.clear;

                                EditorGUILayout.ToggleLeft("", true, GUILayout.Width(10f));

                                GUI.color = Color.yellow;

                                drawMoveEvents = EditorGUILayout.Foldout(drawMoveEvents, "Events", true);

                                GUI.color = guiColor;
                            }
                            EditorGUILayout.EndHorizontal();

                            if (drawMoveEvents)
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PropertyField(MoveOnStart);
                                    EditorGUILayout.PropertyField(MoveOnComplete);
                                }
                                EditorGUILayout.EndVertical();
                            }
                        }
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndVertical();
                }
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawRotate()
        {
            Color guiColor = GUI.color;

            GUI.color = RotateEnabled.boolValue ? Color.green : Color.red;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                EditorGUILayout.BeginHorizontal();
                {
                    RotateEnabled.boolValue = EditorGUILayout.ToggleLeft("", RotateEnabled.boolValue, GUILayout.Width(30f));

                    drawRotate = EditorGUILayout.Foldout(drawRotate, "Rotate", true);

                    GUI.color = guiColor;
                }
                EditorGUILayout.EndHorizontal();

                if (drawRotate)
                {
                    GUI.color = RotateEnabled.boolValue ? Color.green : Color.red;
                    EditorGUILayout.BeginVertical();
                    {
                        GUI.color = guiColor;

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            EditorGUILayout.PropertyField(RotateAnimationType);

                            if (target.Animation.Rotate.AnimationType != AnimationType.Punch)
                                EditorGUILayout.PropertyField(RotateRotateMode);

                            if (target.Animation.Rotate.AnimationType == AnimationType.Loop)
                            {
                                EditorGUILayout.BeginHorizontal();

                                EditorGUILayout.BeginVertical();

                                EditorGUILayout.PrefixLabel("Loop Type");
                                RotateLoopType.enumValueIndex = EditorGUILayout.Popup(RotateLoopType.enumValueIndex, RotateLoopType.enumDisplayNames);

                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();

                                EditorGUILayout.PrefixLabel("Number Of Loops");
                                RotateNumberOfLoops.intValue = EditorGUILayout.IntField(RotateNumberOfLoops.intValue);

                                EditorGUILayout.EndVertical();

                                EditorGUILayout.EndHorizontal();
                            }

                            EditorGUILayout.Space();

                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Start Delay");
                                    RotateStartDelay.floatValue = EditorGUILayout.FloatField(RotateStartDelay.floatValue);
                                }
                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Duration");
                                    RotateDuration.floatValue = EditorGUILayout.FloatField(RotateDuration.floatValue);
                                }
                                EditorGUILayout.EndVertical();
                            }
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            {
                                if (target.Animation.Rotate.AnimationType == AnimationType.Punch)
                                {
                                    EditorGUILayout.BeginVertical();

                                    EditorGUILayout.PrefixLabel("Vibrato");
                                    RotateVibrato.intValue = EditorGUILayout.IntField(RotateVibrato.intValue);

                                    EditorGUILayout.EndVertical();

                                    EditorGUILayout.BeginVertical();

                                    EditorGUILayout.PrefixLabel("Elasticity");
                                    RotateElasticity.floatValue = EditorGUILayout.FloatField(RotateElasticity.floatValue);

                                    EditorGUILayout.EndVertical();
                                }
                            }
                            EditorGUILayout.EndHorizontal();
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            RotateUseCustomFromAndTo.boolValue = EditorGUILayout.ToggleLeft("Use Custom From and To", RotateUseCustomFromAndTo.boolValue);

                            EditorGUILayout.Space();

                            if (RotateUseCustomFromAndTo.boolValue)
                            {
                                EditorGUILayout.PropertyField(RotateFrom);
                                EditorGUILayout.PropertyField(RotateTo);
                            }
                            else
                                EditorGUILayout.PropertyField(RotateBy);
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                        {
                            RotateIgnoreTimeScale.boolValue = EditorGUILayout.ToggleLeft("Ignore Time Scale", RotateIgnoreTimeScale.boolValue);
                            RotateSpeedBased.boolValue = EditorGUILayout.ToggleLeft("Speed Based", RotateSpeedBased.boolValue);
                        }
                        EditorGUILayout.EndHorizontal();

                        if (target.Animation.Rotate.AnimationType != AnimationType.Punch)
                        {
                            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Ease Type");
                                    RotateEaseType.enumValueIndex = EditorGUILayout.Popup(RotateEaseType.enumValueIndex, RotateEaseType.enumDisplayNames);
                                }
                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();
                                {
                                    if (target.Animation.Rotate.EaseType == EaseType.Ease)
                                    {
                                        EditorGUILayout.PrefixLabel("Ease");
                                        RotateEase.enumValueIndex = EditorGUILayout.Popup(RotateEase.enumValueIndex, RotateEase.enumDisplayNames);
                                    }
                                    else
                                    {
                                        EditorGUILayout.PrefixLabel("Curve");
                                        RotateAnimationCurve.animationCurveValue = EditorGUILayout.CurveField(RotateAnimationCurve.animationCurveValue);
                                    }
                                }
                                EditorGUILayout.EndVertical();
                            }
                            EditorGUILayout.EndHorizontal();
                        }

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            EditorGUILayout.BeginHorizontal();
                            {
                                GUI.color = Color.clear;

                                EditorGUILayout.ToggleLeft("", true, GUILayout.Width(10f));

                                GUI.color = Color.yellow;

                                drawRotateEvents = EditorGUILayout.Foldout(drawRotateEvents, "Events", true);

                                GUI.color = guiColor;
                            }
                            EditorGUILayout.EndHorizontal();

                            if (drawRotateEvents)
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PropertyField(RotateOnStart);
                                    EditorGUILayout.PropertyField(RotateOnComplete);
                                }
                                EditorGUILayout.EndVertical();
                            }
                        }
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndVertical();
                }
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawScale()
        {
            Color guiColor = GUI.color;

            GUI.color = ScaleEnabled.boolValue ? Color.green : Color.red;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                EditorGUILayout.BeginHorizontal();
                {
                    ScaleEnabled.boolValue = EditorGUILayout.ToggleLeft("", ScaleEnabled.boolValue, GUILayout.Width(30f));

                    drawScale = EditorGUILayout.Foldout(drawScale, "Scale", true);

                    GUI.color = guiColor;
                }
                EditorGUILayout.EndHorizontal();

                if (drawScale)
                {
                    GUI.color = ScaleEnabled.boolValue ? Color.green : Color.red;
                    EditorGUILayout.BeginVertical();
                    {
                        GUI.color = guiColor;

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            EditorGUILayout.PropertyField(ScaleAnimationType);

                            if (target.Animation.Scale.AnimationType == AnimationType.Loop)
                            {
                                EditorGUILayout.BeginHorizontal();

                                EditorGUILayout.BeginVertical();

                                EditorGUILayout.PrefixLabel("Loop Type");
                                ScaleLoopType.enumValueIndex = EditorGUILayout.Popup(ScaleLoopType.enumValueIndex, ScaleLoopType.enumDisplayNames);

                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();

                                EditorGUILayout.PrefixLabel("Number Of Loops");
                                ScaleNumberOfLoops.intValue = EditorGUILayout.IntField(ScaleNumberOfLoops.intValue);

                                EditorGUILayout.EndVertical();

                                EditorGUILayout.EndHorizontal();
                            }

                            EditorGUILayout.Space();

                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Start Delay");
                                    ScaleStartDelay.floatValue = EditorGUILayout.FloatField(ScaleStartDelay.floatValue);
                                }
                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Duration");
                                    ScaleDuration.floatValue = EditorGUILayout.FloatField(ScaleDuration.floatValue);
                                }
                                EditorGUILayout.EndVertical();
                            }
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            {
                                if (target.Animation.Scale.AnimationType == AnimationType.Punch)
                                {
                                    EditorGUILayout.BeginVertical();

                                    EditorGUILayout.PrefixLabel("Vibrato");
                                    ScaleVibrato.intValue = EditorGUILayout.IntField(ScaleVibrato.intValue);

                                    EditorGUILayout.EndVertical();

                                    EditorGUILayout.BeginVertical();

                                    EditorGUILayout.PrefixLabel("Elasticity");
                                    ScaleElasticity.floatValue = EditorGUILayout.FloatField(ScaleElasticity.floatValue);

                                    EditorGUILayout.EndVertical();
                                }
                            }
                            EditorGUILayout.EndHorizontal();
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            ScaleUseCustomFromAndTo.boolValue = EditorGUILayout.ToggleLeft("Use Custom From and To", ScaleUseCustomFromAndTo.boolValue);

                            EditorGUILayout.Space();

                            if (ScaleUseCustomFromAndTo.boolValue)
                            {
                                EditorGUILayout.PropertyField(ScaleFrom);
                                EditorGUILayout.PropertyField(ScaleTo);
                            }
                            else
                                EditorGUILayout.PropertyField(ScaleBy);
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                        {
                            ScaleIgnoreTimeScale.boolValue = EditorGUILayout.ToggleLeft("Ignore Time Scale", ScaleIgnoreTimeScale.boolValue);
                            ScaleSpeedBased.boolValue = EditorGUILayout.ToggleLeft("Speed Based", ScaleSpeedBased.boolValue);
                        }
                        EditorGUILayout.EndHorizontal();

                        if (target.Animation.Scale.AnimationType != AnimationType.Punch)
                        {
                            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PrefixLabel("Ease Type");
                                    ScaleEaseType.enumValueIndex = EditorGUILayout.Popup(ScaleEaseType.enumValueIndex, ScaleEaseType.enumDisplayNames);
                                }
                                EditorGUILayout.EndVertical();

                                EditorGUILayout.BeginVertical();
                                {
                                    if (target.Animation.Scale.EaseType == EaseType.Ease)
                                    {
                                        EditorGUILayout.PrefixLabel("Ease");
                                        ScaleEase.enumValueIndex = EditorGUILayout.Popup(ScaleEase.enumValueIndex, ScaleEase.enumDisplayNames);
                                    }
                                    else
                                    {
                                        EditorGUILayout.PrefixLabel("Curve");
                                        ScaleAnimationCurve.animationCurveValue = EditorGUILayout.CurveField(ScaleAnimationCurve.animationCurveValue);
                                    }
                                }
                                EditorGUILayout.EndVertical();
                            }
                            EditorGUILayout.EndHorizontal();
                        }

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        {
                            EditorGUILayout.BeginHorizontal();
                            {
                                GUI.color = Color.clear;

                                EditorGUILayout.ToggleLeft("", true, GUILayout.Width(10f));

                                GUI.color = Color.yellow;

                                drawScaleEvents = EditorGUILayout.Foldout(drawScaleEvents, "Events", true);

                                GUI.color = guiColor;
                            }
                            EditorGUILayout.EndHorizontal();

                            if (drawScaleEvents)
                            {
                                EditorGUILayout.BeginVertical();
                                {
                                    EditorGUILayout.PropertyField(ScaleOnStart);
                                    EditorGUILayout.PropertyField(ScaleOnComplete);
                                }
                                EditorGUILayout.EndVertical();
                            }
                        }
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndVertical();
                }
            }
            EditorGUILayout.EndVertical();
        }
        #endregion
    }
}
