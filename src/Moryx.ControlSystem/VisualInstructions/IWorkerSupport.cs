﻿// Copyright (c) 2022, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;

namespace Moryx.ControlSystem.VisualInstructions
{
    /// <summary>
    /// Facade for worker support module
    /// </summary>
    public interface IWorkerSupport
    {
        /// <summary>
        /// Get all instructions for a given client identifier
        /// </summary>
        IReadOnlyList<ActiveInstruction> GetInstructions(string identifier);

        /// <summary>
        /// Add an instruction for an identifier
        /// </summary>
        void AddInstruction(string identifier, ActiveInstruction instruction);

        /// <summary>
        /// Clear an instruction on screen
        /// </summary>
        void ClearInstruction(string identifier, ActiveInstruction instruction);

        /// <summary>
        /// Complete an instruction with the selected result
        /// </summary>
        void CompleteInstruction(string identifier, long instructionId, string result);

        /// <summary>
        /// Event raised when an instruction was added
        /// </summary>
        event EventHandler<InstructionEventArgs> InstructionAdded;

        /// <summary>
        /// Event raised when an instruction was removed
        /// </summary>
        event EventHandler<InstructionEventArgs> InstructionCleared;
    }

    /// <summary>
    /// Event args for instruction events
    /// </summary>
    public class InstructionEventArgs : EventArgs
    {
        /// <summary>
        /// Create new instance
        /// </summary>
        public InstructionEventArgs(string identifier, ActiveInstruction instruction)
        {
            Identifier = identifier;
            Instruction = instruction;
        }

        /// <summary>
        /// Identifier of source
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Referenced instruction
        /// </summary>
        public ActiveInstruction Instruction { get; }
    }
}