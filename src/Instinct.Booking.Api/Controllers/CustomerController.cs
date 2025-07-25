﻿using FluentValidation;
using Instinct.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Instinct.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Instinct.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNumber;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Instinct.Booking.Application.Exceptions;
using Instinct.Booking.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Instinct.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createCustomerCommand,
            [FromServices] IValidator<CreateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel model,
            [FromServices] IUpdateCustomerCommand updateCustomerCommand,
            [FromServices] IValidator<UpdateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(
            int customerId,
            [FromServices] IDeleteCustomerCommand deleteCustomerCommand)
        {
            if (customerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteCustomerCommand.Execute(customerId);
            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllCustomersQuery getAllCustomerQuery)
        {
            var data = await getAllCustomerQuery.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-id/{customerId}")]
        public async Task<IActionResult> GetById(
            int customerId,
            [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery)
        {
            if (customerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getCustomerByIdQuery.Execute(customerId);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-documentNumber/{documentNumber}")]
        public async Task<IActionResult> GetByDocumentNumber(
            string documentNumber,
            [FromServices] IGetCustomerByDocNumberQuery getCustomerByDocumentNumberQuery)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getCustomerByDocumentNumberQuery.Execute(documentNumber);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));


        }
    }
}
