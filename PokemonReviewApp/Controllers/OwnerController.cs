using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController: Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController( IOwnerRepository ownerRepository, IMapper mapper, IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type=typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }
            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(owner);
        }

        [HttpGet("PokemonOwner/{pokeId}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonOwners(int pokeId)

        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerOfPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }

        [HttpGet("OwnerPokemon/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerPokemon(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var pokemons = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }

    }
}
