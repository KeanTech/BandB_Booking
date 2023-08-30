using B_B_ClassLibrary.Enums;
using B_B_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_B_ClassLibrary.BusinessModels
{
    public class Contract
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime? SignedDate { get; set; } = DateTime.Now;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public ContractState State{ get; set; }

        public Contract()
        {
            
        }

        public Contract(DbContract contract)
        {
            Id = contract.Id;
            UserId = contract.UserId;
            RoomId = contract.RoomId;
            SignedDate = contract.SignedDate;
            FromDate = contract.FromDate;
            ToDate = contract.ToDate;
            State = contract.State;
        }
    }
    public static class ContractExtensions
    {
        public static List<Contract> ConvertToContracts(this List<DbContract> dbContracts)
        {
            List<Contract> newContracts = new List<Contract>();
            foreach (DbContract contract in dbContracts)
            {
                newContracts.Add(new Contract(contract));
            }
            return newContracts;
        }

        public static List<DbContract> ConvertToDbContracts(this List<Contract> contracts)
        {
            List<DbContract> newDbContracts = new List<DbContract>();
            foreach (Contract contract in contracts)
            {
                newDbContracts.Add(new DbContract(contract));
            }
            return newDbContracts;
        }
    }
}
